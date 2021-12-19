using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using System.Threading;
using System.Text;
using Auroria.Source.Engine;

namespace Auroria.Output
{
    class TextBox
    {
        #region Fields
        public int maxWidth, lineHeight;
        private string str;
        public Vector2 pos, dims;
        public Color color;

        public SpriteFont font;

        public List<string> lines = new List<string>();
        #endregion

        #region Constructor
        public TextBox(Vector2 POS, string STR, int MAXWIDTH, int LINEHEIGHT, string FONT, Color FONTCOLOR)
        {
            pos = POS;
            str = STR;

            maxWidth = MAXWIDTH;
            lineHeight = LINEHEIGHT;
            color = FONTCOLOR;

            if (str != "")
            {
                ParseLines();
            }
        }
        #endregion

        #region Propoerties
        public string Str
        {
            get
            {
                return str;
            }
            set
            {
                str = value;
                ParseLines();
            }
        }
        #endregion

        #region Methods
        public virtual void ParseLines()
        {
            lines.Clear();
            List<string> wordList = new List<string>();
            string tempString = "";

            int largestWitdh = 0, currentWitdh = 0;

            if (str != "" & str != null)
            {
                wordList = str.Split(' ').ToList<string>();

                for (int i = 0; i < wordList.Count; i++)
                {
                    if (tempString != "")
                    {
                        tempString += " ";
                    }

                    currentWitdh = (int)(font.MeasureString(tempString + wordList[i]).X);

                    if (currentWitdh > largestWitdh && currentWitdh <= maxWidth)
                    {
                        largestWitdh = currentWitdh;
                    }

                    if (currentWitdh <= maxWidth)
                    {
                        tempString += wordList[i];
                    }
                    else
                    {
                        lines.Add(tempString);

                        tempString = wordList[i];
                    }
                }

                if (tempString != "")
                {
                    lines.Add(tempString);
                }

                SetDims(largestWitdh);

            }
        }

        public virtual void SetDims(int LARGESTWITDH)
        {
            dims = new Vector2(LARGESTWITDH, lineHeight * lines.Count);
        }

        public virtual void Draw(Vector2 OFFSET)
        {
            for (int i = 0; i < lines.Count; i++)
            {
                Globals.spriteBatch.DrawString(font, lines[i], OFFSET + new Vector2(pos.X, pos.Y + (lineHeight * i)), color);
            }
        }
        #endregion
    }
}
