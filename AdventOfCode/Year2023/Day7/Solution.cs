using AdventOfCode;
using AdventOfCode2023.StringExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2023.Year2023.Day7
{
    public class Solution : SolutionBase
    {
        public class CamelCard : IComparable<CamelCard>
        {
            public char[] Cards { get; set; } = new char[5];
            public int Bid { get; set; }

            public Dictionary<char, int> CardsDic
            {
                get
                {
                    var dic = new Dictionary<char, int>();
                    foreach (var card in Cards)
                    {
                        if (dic.ContainsKey(card))
                        {
                            dic[card]++;
                        }
                        else
                        {
                            dic[card] = 1;
                        }
                    }
                    return dic;
                }
            }

            public enum Type
            {
                HighCard,
                OnePair,
                TwoPair,
                ThereeOfAKind,
                FullHouse,
                FourOfAKind,
                FiveOfAKind,
            }

            public Type FindType()
            {
                var dictionary = new Dictionary<char, int>();

                if (CardsDic.Any(x => x.Value == 5)) return Type.FiveOfAKind;
                if (CardsDic.Any(x => x.Value == 4)) return Type.FourOfAKind;
                if (CardsDic.Any(x => x.Value == 3))
                {
                    if (CardsDic.Where(x => x.Value < 3).Any(x => x.Value == 2)) return Type.FullHouse;
                    return Type.ThereeOfAKind;
                }
                if (CardsDic.Any(x => x.Value == 2))
                {
                    if (CardsDic.Count(x => x.Value == 2) == 2) return Type.TwoPair;
                    return Type.OnePair;
                }
                return Type.HighCard;
            }

            public int CompareTo(CamelCard other)
            {
                if (this.FindType() > other.FindType())
                {
                    return 1;
                }
                if (this.FindType() < other.FindType())
                {
                    return -1;
                }
                if (this.FindType() == other.FindType())
                {
                    for (global::System.Int32 i = 0; i < this.Cards.Length; i++)
                    {
                        string order = "AKQJT98765432";
                        int indexX = order.IndexOf(this.Cards[i]);
                        int indexY = order.IndexOf(other.Cards[i]);
                        if (indexX < indexY)
                            return 1;
                        if (indexX > indexY)
                            return -1;
                    }
                }
                return 0;
            }
        }

        public class CamelCard2 : IComparable<CamelCard2>
        {
            public char[] Cards { get; set; } = new char[5];
            public int Bid { get; set; }

            public Dictionary<char, int> CardsDic
            {
                get
                {
                    var dic = new Dictionary<char, int>();
                    foreach (var card in Cards.Where(c => c != 'J'))
                    {
                        if (dic.ContainsKey(card))
                        {
                            dic[card]++;
                        }
                        else
                        {
                            dic[card] = 1;
                        }
                    }

                    if (dic.Any())
                    {
                        KeyValuePair<char, int> maxEntry = dic.Aggregate((x, y) => x.Value > y.Value ? x : y);

                        dic[maxEntry.Key] += Cards.Count(c => c == 'J');
                    }
                    else
                    {
                        dic['J'] = 5;
                    }
                    

                    return dic;
                }
            }

            public enum Type
            {
                HighCard,
                OnePair,
                TwoPair,
                ThereeOfAKind,
                FullHouse,
                FourOfAKind,
                FiveOfAKind,
            }

            public Type FindType()
            {
                var dictionary = new Dictionary<char, int>();

                if (CardsDic.Any(x => x.Value == 5)) return Type.FiveOfAKind;
                if (CardsDic.Any(x => x.Value == 4)) return Type.FourOfAKind;
                if (CardsDic.Any(x => x.Value == 3))
                {
                    if (CardsDic.Where(x => x.Value < 3).Any(x => x.Value == 2)) return Type.FullHouse;
                    return Type.ThereeOfAKind;
                }
                if (CardsDic.Any(x => x.Value == 2))
                {
                    if (CardsDic.Count(x => x.Value == 2) == 2) return Type.TwoPair;
                    return Type.OnePair;
                }
                return Type.HighCard;
            }

            public int CompareTo(CamelCard2 other)
            {
                if (this.FindType() > other.FindType())
                {
                    return 1;
                }
                if (this.FindType() < other.FindType())
                {
                    return -1;
                }
                if (this.FindType() == other.FindType())
                {
                    for (global::System.Int32 i = 0; i < this.Cards.Length; i++)
                    {
                        string order = "AKQT98765432J";
                        int indexX = order.IndexOf(this.Cards[i]);
                        int indexY = order.IndexOf(other.Cards[i]);
                        if (indexX < indexY)
                            return 1;
                        if (indexX > indexY)
                            return -1;
                    }
                }
                return 0;
            }
        }
        public override string Part1Solver()
        {
            var lines = Input.SplitByNewline();
            var camelsCard = new List<CamelCard>();
            foreach (var line in lines)
            {
                camelsCard.Add(new CamelCard
                {
                    Cards = line.Split(" ")[0].ToCharArray(),
                    Bid = int.Parse(line.Split(" ")[1])
                });
            }

            camelsCard.Sort((x, y) =>
            {
                return x.CompareTo(y);
            });

            var result = 0;

            for (int i = 0; i < camelsCard.Count; i++)
            {
                result += camelsCard[i].Bid * (i + 1);
            }

            return result.ToString();
        }

        public override string Part2Solver()
        {
            var lines = Input.SplitByNewline();
            var camelsCard = new List<CamelCard2>();
            foreach (var line in lines)
            {
                camelsCard.Add(new CamelCard2
                {
                    Cards = line.Split(" ")[0].ToCharArray(),
                    Bid = int.Parse(line.Split(" ")[1])
                });
            }

            camelsCard.Sort((x, y) =>
            {
                return x.CompareTo(y);
            });

            var result = 0;

            for (int i = 0; i < camelsCard.Count; i++)
            {
                result += camelsCard[i].Bid * (i + 1);
            }

            return result.ToString();
        }
    }
}
