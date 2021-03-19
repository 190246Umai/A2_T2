using System;
using System.Windows.Forms;

namespace Trail
{
    public partial class Calculator : Form
    {
        public Calculator()
        {
            InitializeComponent();
           

        }

        //PRINT OUT THE RECIPT FORM
        private void Reciept_Click_1(object sender, EventArgs e)
        {
            //passed args to the recipt form
            Receipt frm2 = new Receipt(FName.Text, SName.Text, CtyAddress.Text, StatAddress.Text, StAddress.Text, zip.Text, DatePaid.Text, PayMethod.Text, TotalDT.Text, TotalEx.Text, TotalBD.Text, TA.Text, QtyOne.Text, QtyTwo.Text,  QtyThree.Text);
            frm2.Show();//Makes the Receipt form visible
        }

        //CALCULATE THE TOTAL AMOUNT
        private void CALCULATE_Click(object sender, EventArgs e)
        {
            //gets the amount of each text 
            int dt = int.Parse(TotalDT.Text);
            int ex = int.Parse(TotalEx.Text);
            int bd = int.Parse(TotalBD.Text);
            int tA;

            int dtqty = int.Parse(QtyOne.Text);
            int exqty = int.Parse(QtyTwo.Text);
            int bdqty = int.Parse(QtyThree.Text);


            //Total Amount Discount
            tA = dt + ex + bd;
            TA.Text = "" + tA + ".00";

            if (dtqty == 2 || exqty == 2 || bdqty == 2)
            {

                //display each Discouunt in Display Discount
                double sum = 0;
                for (int i = 0; i < listBox1.Items.Count; i++)
                {
                    sum += Convert.ToDouble(listBox1.Items[i]);
                }
                listBox1.Items[0] = "K " + sum;
            }

        }

        //EACH QTY BELONGS TO EACH MACHINES. 
        private void QtyOne_TextChanged(object sender, EventArgs e)
        {
            int dtqty = int.Parse(QtyOne.Text);//gets value in quantity

            double tA1, Discount1;
            DumpTruckPrice.Text = "K200.00";//fixed price 

            if (dtqty ==2)//if qty is equal to 2
            {
                Discount1 = (0.2 * 200);
                tA1 = (200 - Discount1);
                TotalDT.Text = "" + tA1;
                listBox1.Items.Add(Discount1);
            }
            else//If not equal to 2
            {
                tA1 = (dtqty * 200);
                TotalDT.Text = "" + tA1;
            }
            
        }
        private void QtyTwo_TextChanged(object sender, EventArgs e)
        {

            int exqty = int.Parse(QtyTwo.Text);

            double tA2, Discount2;

            ExcavatorPrice.Text = "K5,000.00";

            if (exqty == 2)
            {
                Discount2 = (0.3 * 5000);
                tA2 = (5000 - Discount2);
                TotalEx.Text = "" + tA2;
                listBox1.Items.Add(Discount2);

            }
            else
            {
                tA2 = (exqty * 5000);
                TotalEx.Text = "" + tA2;

            }
        }
        private void QtyThree_TextChanged(object sender, EventArgs e)
        {
            int bdqty = int.Parse(QtyThree.Text);

            double tA3, Discount3;

            BullDozerPrice.Text = "K5,500.00";

            if (bdqty == 2)
            {
                Discount3 = (0.3 * 5500);
                tA3 = (5500 - Discount3);
                TotalBD.Text = ""+tA3;
                listBox1.Items.Add(Discount3);

            }
            else
            {
                tA3 = (bdqty * 5500);
                TotalBD.Text = ""+tA3;
            }
        }

        //CLEAR ALL THE TEXT FIELDS
        private void reset_Click(object sender, EventArgs e)
        {

            FName.Text = "";
            SName.Text = "";
            StAddress.Text = "";
            CtyAddress.Text = "";
            StatAddress.Text = "";
            zip.Text = " ";
            fax.Text = " ";
            PhnOne.Text = " ";
            PhnTwo.Text = " ";
            PayMethod.Text = " ";
            DatePaid.Text = " ";
            PaymentDetails.Text = " ";
            QtyOne.Text = "0";
            QtyTwo.Text = "0";
            QtyThree.Text = "0";
            DumpTruckPrice.Text = "0";
            ExcavatorPrice.Text = "0";
            BullDozerPrice.Text = "0";
            TotalDT.Text = "0";
            TotalEx.Text = "0";
            TotalBD.Text = "0";
            TA.Text = " ";
            PaymentDetails.Items.Clear();
            listBox1.Items.Clear();
            foreach (int i in checkedListBox1.CheckedIndices)
            {
                checkedListBox1.SetItemCheckState(i, CheckState.Unchecked);
            }
        }

        //For the text box
        private void checkedListBox1_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (e.NewValue == CheckState.Checked)
            {
                PaymentDetails.Items.Add(checkedListBox1.Items[e.Index]);
            }
            else if (e.NewValue == CheckState.Unchecked)
            {
                PaymentDetails.Items.Remove(checkedListBox1.Items[e.Index]);
            }
        }


    }
}
