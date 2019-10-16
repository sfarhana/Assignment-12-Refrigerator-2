using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RefrigeratorAppPractice3
{
    public partial class RefrigeratorUi : Form
    {
        public RefrigeratorUi()
        {
            InitializeComponent();
        }

        Refrigerator refg = new Refrigerator();

        private void SaveButton_Click(object sender, EventArgs e)
        {
            if (refg.MaxWeight == 0)
            {
                refg.MaxWeight = Convert.ToDouble(maxWeightTakeTextBox.Text);
                maxWeightTakeTextBox.Text = "";
            }
            else
            {
                MessageBox.Show("MaxWeight can be set only once");
                maxWeightTakeTextBox.Text = "";
            }
        }

        List<ItemEntry> ItemInfo = new List<ItemEntry>();
        class ItemEntry
        {
            public int ItemNo { set; get; }
            public double WeightPerUnit { set; get; }
            public double TotalWeight { set; get; }

        }

        private void EnterButton_Click(object sender, EventArgs e)
        {
            int item = int.Parse(itemTextBox.Text);
            double weight = Convert.ToDouble(weightTextBox.Text);
            double amount = item * weight;
            
            if (amount <= refg.RemainingWeight )
            {
                refg.CalculateWeight(item, weight);

                currentWeightTextBox.Text = refg.CurrentWeight.ToString();
                remainingWeightTextBox.Text = refg.RemainingWeight.ToString();

                ItemDisplay(item, weight, amount);

                itemTextBox.Text = "";
                weightTextBox.Text = "";
            }
            else
            {
                MessageBox.Show("Your Given Amount Cannot be Entered. It will be Overflown.");
            }
        }
        public void ItemDisplay(int item, double weight, double amount)
        {
            string output= "No Of Item, Weight / Unit, Total Weight"+Environment.NewLine;

            ItemEntry ItmEnt = new ItemEntry();

            ItmEnt.ItemNo = item;
            ItmEnt.WeightPerUnit = weight;
            ItmEnt.TotalWeight = amount;

            ItemInfo.Add(ItmEnt);

            foreach (ItemEntry IE in ItemInfo)
            {
                output += IE.ItemNo + "," + IE.WeightPerUnit + "," + IE.TotalWeight+Environment.NewLine;
            }

            int totalitemno = ItemInfo.Sum(x => x.ItemNo);
            double totalweightperunit= ItemInfo.Sum(x => x.WeightPerUnit);
            double totalweight= ItemInfo.Sum(x => x.TotalWeight);

            richTextBox.Text = output+Environment.NewLine+"-----------------------" +Environment.NewLine+ "Total " + totalitemno + " ," + totalweightperunit + " ," + totalweight + "/[Max Weight]";


        }
    }
}
