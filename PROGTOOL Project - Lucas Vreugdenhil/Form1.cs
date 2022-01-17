using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PROGTOOL_Project___Lucas_Vreugdenhil
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btn_Click(object sender, EventArgs e)
        {
            //clears listbox, zodat je niet hoeft te scrollen.
            lbxOutput.Items.Clear();
            try
            {
                //informatie halen uit textboxen
                int beginWaarde = int.Parse(txtBeginwaarde.Text);
                int eindWaarde = int.Parse(txtEindwaarde.Text);
                int stapGrootte = int.Parse(txtStapgrootte.Text);
                int ifCompareValue = 0;
                bool ifStatement = boxIf.Enabled;
                
                //checken of ik de value van het if statement moet pakken.
                if(ifStatement)
                {
                    ifCompareValue = int.Parse(txtIf.Text);
                }

                //strings aanmaken die verder in de code gebruikt worden.
                string stapBerekening = "";
                string loopVergelijking = "";
                string ifVergelijking = "";

                //checken of stapgrootte geen - getal is(om te voorkomen dat er -++, ---, - *  etc. komt te staan.)
                if (stapGrootte < 1)
                {
                    MessageBox.Show("Vul een stapgrootte in die grote dan nul is.");
                }

                //Checken welke radiobutton geselecteerd is en de juiste vergelijking opslaan.
                if (rbtnGreater.Checked)
                {
                    loopVergelijking = ">";
                    if (beginWaarde < eindWaarde)
                    {
                        lbxOutput.Items.Add("//beginwaarde is niet groter dan eindwaarde. De loop zal niet loopen");
                        lbxOutput.Items.Add("");
                    }
                }
                if (rbtnGreaterEqual.Checked)
                {
                    loopVergelijking = ">=";
                    if (beginWaarde < eindWaarde)
                    {
                        lbxOutput.Items.Add("//beginwaarde is niet groter of gelijk aan de eindwaarde. De loop zal niet loopen");
                        lbxOutput.Items.Add("");
                    }
                }
                if (rbtnSmaller.Checked)
                {
                    loopVergelijking = "<";
                    if (beginWaarde > eindWaarde)
                    {
                        lbxOutput.Items.Add("//beginwaarde is niet kleiner dan eindwaarde. De loop zal niet loopen");
                        lbxOutput.Items.Add("");
                    }
                }
                if (rbtnSmallerEqual.Checked)
                {
                    loopVergelijking = "<=";
                    if (beginWaarde > eindWaarde)
                    {
                        lbxOutput.Items.Add("//beginwaarde is niet kleiner of gelijk aan de eindwaarde. De loop zal niet loopen");
                        lbxOutput.Items.Add("");
                    }
                }

                //Checken wat er bij de stapberekening gebeurd
                if (rbtnPlus.Checked && stapGrootte > 1)
                {
                    stapBerekening = " + " + stapGrootte;
                }
                if (rbtnMinus.Checked && stapGrootte > 1)
                {
                    stapBerekening = " - " + stapGrootte;
                }
                if (rbtnTimes.Checked && stapGrootte > 1)
                {
                    stapBerekening = " * " + stapGrootte;
                }
                if (rbtnDivide.Checked && stapGrootte > 1)
                {
                    stapBerekening = " / " + stapGrootte;
                }
                if (rbtnPlus.Checked && stapGrootte == 1)
                {
                    stapBerekening = "++";
                }
                if (rbtnMinus.Checked && stapGrootte == 1)
                {
                    stapBerekening = "--";
                }
                if (rbtnTimes.Checked && stapGrootte == 1)
                {
                    MessageBox.Show("Een stapgrootte van * 1 zal blijven loopen.");
                }
                if (rbtnDivide.Checked && stapGrootte == 1)
                {
                    MessageBox.Show("Een stapgrootte van / 1 zal blijven loopen.");
                }
                //if statement in loop
                if(ifStatement)
                {
                    if(rbtnIfGreater.Checked)
                    {
                        ifVergelijking = ">";
                    }
                    if(rbtnIfGreaterEqual.Checked)
                    {
                        ifVergelijking = ">=";
                    }
                    if(rbtnIfSmaller.Checked)
                    {
                        ifVergelijking = "<";
                    }
                    if(rbtnIfSmallerEqual.Checked)
                    {
                        ifVergelijking = "<=";
                    }
                }
                //for of while loop vormgeven en opslaan in een string.
                if (rbtnFor.Checked)
                {
                    //werking van de for loop uitleggen FORLOOP.
                    lbxOutput.Items.Add("/**");
                    lbxOutput.Items.Add(" * In deze for loop wordt er gekeken naar:");
                    lbxOutput.Items.Add($" * Voor elke keer dat i {loopVergelijking} {eindWaarde} is herhaalt hij de code erin nog een keer.");
                    lbxOutput.Items.Add($" * Aangezien we met een for loop vaak niet voor eeuwig willen herhalen hebben we i{stapBerekening}.");
                    lbxOutput.Items.Add(" * Dit zorgt ervoor dat i veranderd en wanneer goed gedaan kun je gemakkelijk kiezen");
                    lbxOutput.Items.Add(" * hoe vaak er geloopt wordt.");
                    lbxOutput.Items.Add(" */");

                    //printen van de for loop FORLOOP.
                    lbxOutput.Items.Add($"for(int i = {beginWaarde}; i {loopVergelijking} {eindWaarde}; i{stapBerekening})");
                    lbxOutput.Items.Add("{");

                    //begin if statement FORLOOP.
                    if (ifStatement)
                    {
                        lbxOutput.Items.Add("   //Zo gebruik je een if statement binnen een for loop.");
                        lbxOutput.Items.Add($"   if(i {ifVergelijking} {ifCompareValue})");
                        lbxOutput.Items.Add("   {");
                        //checken of hij binnen moet printen FORLOOP IF.
                        if (checkWaarde.Checked && rbtnBinnen.Checked)
                        {
                            lbxOutput.Items.Add($"      //Hier wordt waarde i elke loop wanneer i {ifVergelijking} {ifCompareValue} is geprint.");
                            lbxOutput.Items.Add("       Console.WriteLine(i);");
                        }
                        lbxOutput.Items.Add("   }");
                    }
                    else
                    {
                        //checken of hij binnen moet printen FORLOOP.
                        if (checkWaarde.Checked && rbtnBinnen.Checked)
                        {
                            lbxOutput.Items.Add("//Hier wordt waarde i elke loop geprint.");
                            lbxOutput.Items.Add("Console.WriteLine(i);");
                        }
                    }

                    lbxOutput.Items.Add("}");

                    //checken of hij buiten moet printen FORLOOP.
                    if (checkWaarde.Checked && rbtnBuiten.Checked)
                    {
                        lbxOutput.Items.Add("//Hier wordt waarde i alleen na de loop geprint.");
                        lbxOutput.Items.Add("Console.WriteLine(i);");
                    }
                }
                else
                {
                    //werking van de while loop uitleggen WHILELOOP.
                    lbxOutput.Items.Add("/**");
                    lbxOutput.Items.Add(" * In deze loop wordt er gekeken naar:");
                    lbxOutput.Items.Add($" * Wanneer i {loopVergelijking} {eindWaarde} is herhaalt hij de code binnen de curly braces.");
                    lbxOutput.Items.Add(" * Dit doet hij tot het bovenstaande statement niet meer waar is.");
                    lbxOutput.Items.Add(" * Hier wordt de waarde i voor de loop aangemaakt.");
                    lbxOutput.Items.Add(" * Als je een eeuwige loop wilt kun je in while() een uitdrukking zetten die waar is.");
                    lbxOutput.Items.Add(" * Bijvoorbeeld: 1 == 1");
                    lbxOutput.Items.Add(" */");

                    //printen van de WHILELOOP.
                    lbxOutput.Items.Add($"int i = {beginWaarde};");
                    lbxOutput.Items.Add($"while(i {loopVergelijking} {eindWaarde})");
                    lbxOutput.Items.Add("{");

                    //begin if statement WHILELOOP.
                    if (ifStatement)
                    {
                        lbxOutput.Items.Add("   //Zo gebruik je een if statement binnen een while loop.");
                        lbxOutput.Items.Add($"   if(i {ifVergelijking} {ifCompareValue})");
                        lbxOutput.Items.Add("   {");
                        //checken of hij binnen moet printen WHILELOOP IF.
                        if (checkWaarde.Checked && rbtnBinnen.Checked)
                        {
                            lbxOutput.Items.Add($"      //Hier wordt waarde i elke loop wanneer i {ifVergelijking} {ifCompareValue} is geprint.");
                            lbxOutput.Items.Add("       Console.WriteLine(i);");
                        }
                        lbxOutput.Items.Add("   }");
                    } else
                    {
                        //checken of hij binnen moet printen WHILELOOP.
                        if (checkWaarde.Checked && rbtnBinnen.Checked)
                        {
                            lbxOutput.Items.Add("//Hier wordt waarde i elke loop geprint.");
                            lbxOutput.Items.Add("Console.WriteLine(i);");
                        }
                    }

                    lbxOutput.Items.Add("   i" + stapBerekening + ";");
                    lbxOutput.Items.Add("}");

                    //checken of hij buiten moet printen WHILELOOP.
                    if (checkWaarde.Checked && rbtnBuiten.Checked)
                    {
                        lbxOutput.Items.Add("//Hier wordt waarde i alleen na de loop geprint.");
                        lbxOutput.Items.Add("Console.WriteLine(i);");
                    }
                }
            }
            catch
            {
                MessageBox.Show("Niet alle waarden zijn ingevuld");
            }
        }

        private void checkWaarde_CheckedChanged(object sender, EventArgs e)
        {
            //checkt of de box voor het printen aanstaat en geeft je toegang tot de binnen/buiten groupbox.
            if (checkWaarde.Checked)
            {
                boxBinnenBuiten.Enabled = true;
            }
            else
            {
                boxBinnenBuiten.Enabled = false;
            }
        }

        private void checkIf_CheckedChanged(object sender, EventArgs e)
        {
            //checkt of de box voor de if statement aanstaat en geeft je toegang tot de if groupbox.
            if (checkIf.Checked)
            {
                boxIf.Enabled = true;
            }
            else
            {
                boxIf.Enabled = false;
            }
        }
    }
}
