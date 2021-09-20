using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SearchString
{
    public partial class frm_Search : Form
    {
        public frm_Search()
        {
            InitializeComponent();
        }

        private void btn_Search_Click(object sender, EventArgs e)
        {
            lbl_Display.Text = "";
            lbl_Output.Text = "";

            if (txt_Text.Text == "")
            {
                lbl_Output.Text = "Please enter the Text";
            }

            if(txt_SubText.Text == "")
            {
                lbl_Output.Text = "Please enter the Sub Text to be searched for ";
            }

            if(txt_Text.Text.Length != 0 || txt_SubText.Text.Length != 0)
            {
                string text = txt_Text.Text.ToLower();
                string subText = txt_SubText.Text.ToLower();
                var result = Search.BoyerMooreSearch(text, subText);

                lbl_Display.Text = $"The Occurence/s position of {txt_SubText.Text} in {txt_Text.Text} is : ";

                // output
                if (result.Length != 0)
                {
                    lbl_Output.Text = string.Join(", ", result);
                }
                else
                {
                    lbl_Output.Text = "<No Matches>";
                }
            }
               
        }
    }
}
