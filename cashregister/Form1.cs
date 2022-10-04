using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Media;

namespace cashregister
{
    public partial class guitarlogoPicture : Form
    {
        //Golbal Varibles 
        double guitarPrice = 200;
        int numOfGuitar;
        double subGuitar;

        double tunerPrice = 15.76;
        int numOfTuner;
        double subTuner;

        double stringsPrice = .98;
        int numOfString;
        double subString;

        double subTotal;
        double taxRate = .13;
        double taxAmount;
        double totalCost;

        public guitarlogoPicture()
        {
            InitializeComponent();
        }

        private void calculateButton_Click(object sender, EventArgs e)
        {
            try
            {
                //button noise
                SoundPlayer elevatorbutton = new SoundPlayer(Properties.Resources.elevatorbutton);
                elevatorbutton.Play();
                Refresh();
                Thread.Sleep(700);

                ////get inputs
                //slices = Convert.ToInt16(slicesInput.Text);
                numOfGuitar = Convert.ToInt16(guitarInput.Text);
                numOfString = Convert.ToInt16(stringsInput.Text);
                numOfTuner = Convert.ToInt16(tunersInput.Text);

                ////calculations
                //subtotal = slicePrice * slices;
                subGuitar = guitarPrice * numOfGuitar;
                subTuner = tunerPrice * numOfTuner;
                subString = stringsPrice * numOfString;

                //taxAmount = subtotal * taxRate;
                //totalAmount = subtotal + taxAmount;
                subTotal = subGuitar + subTuner + subString;
                taxAmount = subTotal * taxRate;
                totalCost = subTotal + taxAmount;

                ////outputs
                //subtotalOutput.Text = $"{subtotal.ToString("C")}";
                //taxOutput.Text = $"{taxAmount.ToString("C")}";
                //totalOutput.Text = $"{totalAmount.ToString("C")}";

                //subtotalOutput.Text = $"{}";
                subtotalOutput.Text = $"{subTotal.ToString("$.##")}";
                taxamountOutput.Text = $"{taxAmount.ToString("$.##")}";
                totalamountOutput.Text = $"{totalCost.ToString("$.##")}";
            }
            catch
            {
                subtotalOutput.Text = $"Error";
                taxamountOutput.Text = $"Error";
                totalamountOutput.Text = $"Error";
             }
            //

        }

        private void receiptButton_Click(object sender, EventArgs e)
        {
            //create a sound player and load the alert.wav sound, then play it 
            SoundPlayer elevatorbutton = new SoundPlayer(Properties.Resources.elevatorbutton);
            elevatorbutton.Play();
            Refresh();
            Thread.Sleep(700);

            SoundPlayer printreceipt = new SoundPlayer(Properties.Resources.printreceipt);
            printreceipt.Play();

            Refresh();
            Thread.Sleep(500);
            receiptLabel.Text += $"\n The Write Note";
            Thread.Sleep(500);
            receiptLabel.Text += $"\n\n Order Number: 1337";
            Refresh();
            Thread.Sleep(500);
            receiptLabel.Text += $"\n Date: 12-25-06";
            Refresh();
            Thread.Sleep(500);
            receiptLabel.Text += $"\n\n Guitars                                        {numOfGuitar} @ {guitarPrice}";
            Refresh();
            Thread.Sleep(500);
            receiptLabel.Text += $"\n Tuners                                        {numOfTuner} @ {tunerPrice}";
            Refresh();
            Thread.Sleep(500);
            receiptLabel.Text += $"\n Strings                                        {numOfString} @ {stringsPrice}";
            Refresh();
            Thread.Sleep(500);
            receiptLabel.Text += $"\n\n Subtotal                                        {subtotalOutput.Text}";
            Refresh();
            Thread.Sleep(500);
            receiptLabel.Text += $"\n Tax Amount                              {taxamountOutput.Text}";
            Refresh();
            Thread.Sleep(500);
            receiptLabel.Text += $"\n Total                                              {totalamountOutput.Text}";
            Refresh();
            Thread.Sleep(500);
            receiptLabel.Text += $"\n\n Have a good day, don't fret!";
        }

        private void neworderButton_Click(object sender, EventArgs e)
        {
            //create a sound player and load the alert.wav sound, then play it 
            SoundPlayer elevatorbutton = new SoundPlayer(Properties.Resources.elevatorbutton);
            elevatorbutton.Play();
            Refresh();
            Thread.Sleep(500);

            //reset inputs
            guitarInput.ResetText();
            tunersInput.ResetText();
            stringsInput.ResetText();

            //reset outputs
            subtotalOutput.Text = $"";
            taxamountOutput.Text = $"";
            totalamountOutput.Text = $"";
                       
            //reset receipt
            receiptLabel.Text = "";
        }
               
    }
}
