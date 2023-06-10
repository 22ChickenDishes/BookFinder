using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;

using System.Windows.Documents;
using System.Windows.Media;

namespace BookFinder.Controls
{
    public class PartTextDiscolorTextBlock : TextBlock
    {
        public static readonly DependencyProperty DiscolorationProperty = DependencyProperty.Register("Discoloration", typeof(string), typeof(TextBlock), new PropertyMetadata());

        public static readonly DependencyProperty DiscolorationProperty2 = DependencyProperty.Register("Discoloration2", typeof(string), typeof(TextBlock), new PropertyMetadata());

        public static readonly DependencyProperty ChangeColorProperty = DependencyProperty.Register("ChangeColor", typeof(Color), typeof(TextBlock), new PropertyMetadata());

        public static readonly DependencyProperty ChangeColorProperty2 = DependencyProperty.Register("ChangeColor2", typeof(Color), typeof(TextBlock), new PropertyMetadata());

        /// <summary>
        /// 变色文案
        /// </summary>
        public string Discoloration
        {
            get { return (string)GetValue(DiscolorationProperty); }
            set { SetValue(DiscolorationProperty, value); }
        }

        /// <summary>
        /// 变色文案2
        /// </summary>
        public string Discoloration2
        {
            get { return (string)GetValue(DiscolorationProperty2); }
            set { SetValue(DiscolorationProperty2, value); }
        }

        /// <summary>
        /// 变色的颜色
        /// </summary>
        public Color ChangeColor
        {
            get { return (Color)GetValue(ChangeColorProperty); }
            set { SetValue(ChangeColorProperty, value); }
        }

        /// <summary>
        /// 变色的颜色2
        /// </summary>
        public Color ChangeColor2
        {
            get { return (Color)GetValue(ChangeColorProperty2); }
            set { SetValue(ChangeColorProperty2, value); }

        }

        /// <summary>
        /// 第一个要变色的文本在整个Text的位置，0:最左边 1:中间 2:最右边
        /// </summary>
        private int DiscolorationLocation = 1;

        public PartTextDiscolorTextBlock()
        {
            // 下面是一坨屎 主要用到字符串分割
            this.Loaded += (s, e) =>
            {
                if (this.Text == null || this.Text == string.Empty)
                {
                    return;
                }

                bool IsNewChangeText1 = (Discoloration != null && Discoloration != string.Empty);
                bool IsNewChangeText2 = (Discoloration2 != null && Discoloration2 != string.Empty);

                if (IsNewChangeText2 == true && IsNewChangeText1 == false)
                {
                    IsNewChangeText2 = !(IsNewChangeText1 = true);
                    Discoloration = Discoloration2;
                }

                List<string> strings = new List<string>();
                List<string> strings2 = new List<string>();

                if (IsNewChangeText1)
                {
                    if (this.Text.Contains(Discoloration))
                    {
                        strings = this.Text.Split(Discoloration.ToCharArray(), Discoloration.Length + 1).ToList();
                        if (strings.Count == 3)
                        {

                            if (strings[0] == string.Empty)
                            {
                                DiscolorationLocation = 0;
                                strings.RemoveAll(x => x == string.Empty);
                            }
                            else if (strings[strings.Count - 1] == string.Empty)
                            {
                                DiscolorationLocation = 2;
                                strings.RemoveAll(x => x == string.Empty);
                            }
                            else
                            {
                                DiscolorationLocation = 1;
                                strings.RemoveAll(x => x == string.Empty);
                            }
                        }

                    }
                }
                else
                {
                    return;
                }

                this.Text = string.Empty;

                if (IsNewChangeText2 && IsNewChangeText1 && Discoloration != Discoloration2 && strings.Count > 0)
                {
                    int p = 0;
                    if (DiscolorationLocation == 0)
                    {
                        if (strings[0].Contains(Discoloration2))
                        {
                            strings2 = strings[0].Split(Discoloration2.ToCharArray(), Discoloration2.Length + 1).ToList();
                            if (strings2.Count == 3)
                            {

                                if (strings2[0] == string.Empty)
                                {
                                    strings2.RemoveAll(x => x == string.Empty);
                                }
                                else if (strings2[strings2.Count - 1] == string.Empty)
                                {
                                    p = 2;
                                    strings2.RemoveAll(x => x == string.Empty);
                                }
                                else
                                {
                                    p = 1;
                                    strings2.RemoveAll(x => x == string.Empty);
                                }
                            }
                        }
                    }
                    else if (DiscolorationLocation == 1)
                    {
                        bool b = false;
                        if (strings[0].Contains(Discoloration2))
                        {
                            strings2 = strings[0].Split(Discoloration2.ToCharArray(), Discoloration2.Length + 1).ToList();
                            if (strings2.Count == 3)
                            {
                                b = true;
                                if (strings2[0] == string.Empty)
                                {
                                    strings2.RemoveAll(x => x == string.Empty);
                                }
                                else if (strings2[strings2.Count - 1] == string.Empty)
                                {
                                    p = 2;
                                    strings2.RemoveAll(x => x == string.Empty);
                                }
                                else
                                {
                                    p = 1;
                                    strings2.RemoveAll(x => x == string.Empty);
                                }
                            }
                        }
                        else if (strings[1].Contains(Discoloration2))
                        {
                            strings2 = strings[1].Split(Discoloration2.ToCharArray(), Discoloration2.Length + 1).ToList();
                            if (strings2.Count == 3)
                            {

                                if (strings2[0] == string.Empty)
                                {
                                    strings2.RemoveAll(x => x == string.Empty);
                                }
                                else if (strings2[strings2.Count - 1] == string.Empty)
                                {
                                    p = 2;
                                    strings2.RemoveAll(x => x == string.Empty);
                                }
                                else
                                {
                                    p = 1;
                                    strings2.RemoveAll(x => x == string.Empty);
                                }
                            }
                        }


                    }
                    else if (DiscolorationLocation == 2)
                    {
                        if (strings[0].Contains(Discoloration2))
                        {
                            strings2 = strings[0].Split(Discoloration2.ToCharArray(), Discoloration2.Length + 1).ToList();
                            if (strings2.Count == 3)
                            {

                                if (strings2[0] == string.Empty)
                                {
                                    strings2.RemoveAll(x => x == string.Empty);
                                }
                                else if (strings2[strings2.Count - 1] == string.Empty)
                                {
                                    p = 2;
                                    strings2.RemoveAll(x => x == string.Empty);
                                }
                                else
                                {
                                    p = 1;
                                    strings2.RemoveAll(x => x == string.Empty);
                                }
                            }
                        }




                    }

                    if (strings2.Count == 2)
                    {
                        Run run0 = new Run();
                        run0.Text = Discoloration;
                        run0.Foreground = new SolidColorBrush(ChangeColor);

                        Run run00 = new Run();
                        run00.Text = Discoloration2;
                        run00.Foreground = new SolidColorBrush(ChangeColor2);

                        Run run2 = new Run();
                        Run run3 = new Run();
                        Run run4 = new Run();

                        if (DiscolorationLocation == 0)
                        {
                            if (p == 0)
                            {
                                run2.Text = strings2[0];
                                this.Inlines.Add(run0);
                                this.Inlines.Add(run00);
                                this.Inlines.Add(run2);

                            }
                            else if (p == 1)
                            {
                                run2.Text = strings2[0];
                                run3.Text = strings2[0];
                                this.Inlines.Add(run0);

                                this.Inlines.Add(run2);
                                this.Inlines.Add(run00);
                                this.Inlines.Add(run3);

                            }
                            else if (p == 2)
                            {
                                run2.Text = strings2[0];
                                this.Inlines.Add(run0);

                                this.Inlines.Add(run2);
                                this.Inlines.Add(run00);
                            }
                        }
                        else if (DiscolorationLocation == 1)
                        {
                            bool b = false;

                            if (strings[0].Contains(Discoloration2))
                            {
                                b = true;
                                run2.Text = strings[1];
                            }
                            else if (strings[1].Contains(Discoloration2))
                            {
                                run2.Text = strings[0];
                            }

                            if (p == 0)
                            {
                                run3.Text = strings2[0];
                                if (b)
                                {
                                    this.Inlines.Add(run00);
                                    this.Inlines.Add(run3);
                                    this.Inlines.Add(run0);
                                    this.Inlines.Add(run2);
                                }
                                else
                                {

                                    this.Inlines.Add(run2);
                                    this.Inlines.Add(run0);
                                    this.Inlines.Add(run3);
                                    this.Inlines.Add(run00);

                                }

                            }
                            else if (p == 1)
                            {
                                run3.Text = strings2[0];
                                run4.Text = strings2[1];
                                if (b)
                                {
                                    this.Inlines.Add(run3);
                                    this.Inlines.Add(run00);
                                    this.Inlines.Add(run4);
                                    this.Inlines.Add(run0);
                                    this.Inlines.Add(run2);
                                }
                                else
                                {
                                    this.Inlines.Add(run2);
                                    this.Inlines.Add(run0);
                                    this.Inlines.Add(run3);
                                    this.Inlines.Add(run00);
                                    this.Inlines.Add(run4);

                                }
                            }
                            else if (p == 2)
                            {
                                run3.Text = strings2[0];
                                if (b)
                                {
                                    this.Inlines.Add(run3);
                                    this.Inlines.Add(run00);
                                    this.Inlines.Add(run0);
                                    this.Inlines.Add(run2);

                                }
                                else
                                {
                                    this.Inlines.Add(run2);
                                    this.Inlines.Add(run0);
                                    this.Inlines.Add(run3);
                                    this.Inlines.Add(run00);
                                }
                            }

                        }
                        else if (DiscolorationLocation == 2)
                        {
                            if (p == 0)
                            {
                                run2.Text = strings2[0];

                                this.Inlines.Add(run00);
                                this.Inlines.Add(run2);
                                this.Inlines.Add(run0);

                            }
                            else if (p == 1)
                            {
                                run2.Text = strings2[0];
                                run3.Text = strings2[0];


                                this.Inlines.Add(run2);
                                this.Inlines.Add(run00);
                                this.Inlines.Add(run3);
                                this.Inlines.Add(run0);

                            }
                            else if (p == 2)
                            {
                                run2.Text = strings2[0];


                                this.Inlines.Add(run2);
                                this.Inlines.Add(run00);
                                this.Inlines.Add(run0);
                            }
                        }



                    }

                }
                if ((!(IsNewChangeText2 && IsNewChangeText1 && Discoloration != Discoloration2) || (strings2.Count != 2)) && strings.Count > 0)
                {
                    if (DiscolorationLocation == 0)
                    {
                        Run run0 = new Run();
                        run0.Text = strings[0];

                        Run run1 = new Run();
                        run1.Text = Discoloration;
                        run1.Foreground = new SolidColorBrush(ChangeColor);

                        this.Text = string.Empty;

                        this.Inlines.Add(run1);
                        this.Inlines.Add(run0);

                    }
                    else if (DiscolorationLocation == 1)
                    {
                        Run run0 = new Run();
                        run0.Text = strings[0];

                        Run run1 = new Run();
                        run1.Text = Discoloration;
                        run1.Foreground = new SolidColorBrush(ChangeColor);

                        Run run2 = new Run();
                        run2.Text = strings[1];
                        this.Text = string.Empty;
                        this.Inlines.Add(run0);
                        this.Inlines.Add(run1);
                        this.Inlines.Add(run2);
                    }
                    else if (DiscolorationLocation == 2)
                    {

                        Run run0 = new Run();
                        run0.Text = strings[0];

                        Run run1 = new Run();
                        run1.Text = Discoloration;
                        run1.Foreground = new SolidColorBrush(ChangeColor);
                        this.Text = string.Empty;
                        this.Inlines.Add(run0);
                        this.Inlines.Add(run1);
                    }
                }

            };
        }
    }
}
