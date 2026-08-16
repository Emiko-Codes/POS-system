using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POS_SYSTEM_C__
{
    public partial class Form1 : Form
    {
        Item[] item = new Item[8]; // Initializing the array.
                                   // It stores the eight items that are availaible on the POS system
        List<Item> cart = new List<Item>();// This is the cart. It adds each item in the array to a list.
        const double TAX_RATE = 1.13;// Initializes the tax rate
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            item[0] = new Item("Amino Acid", 24);//This is assigninging each index of the array to the items available.
            item[1] = new Item("Creatine Monohydrate", 30);
            item[2] = new Item("Preworkout", 35);
            item[3] = new Item("Protein Powder", 50);
            item[4] = new Item("Lifting Cap", 20);
            item[5] = new Item("Knee Sleeve", 25);
            item[6] = new Item("Sleep Booster", 30);
            item[7] = new Item("Chocolate Protein", 60);
        }

        private void button13_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

       

        private void button8_Click(object sender, EventArgs e)
        {

        }

        private void button8_Click_1(object sender, EventArgs e) // This is the Checkout button 
        {
            checkout();
        }

        void AddToCart (Item item)
        {
          
            DialogResult result = MessageBox.Show( "|"+item.Iteminfo()+ "|    Add to cart?" , " Add to Cart ", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                cart.Add(item);
                updateTotal();
              
            }//This block of code gives the user the option to select yes or no when they are asked
             //if they want to add the item they selected to the cart.
        }
            
        public void updateTotal()//Updates the total in the cart
        {
            double temptotal = 0;

            foreach (Item item in cart)
                
            {
                temptotal += item.Price;
            }
            double total = temptotal * TAX_RATE;
            TotalLabel.Text = $"${temptotal:F2}";
        }
        public void clearcart()
        {
            cart.Clear();
            TotalLabel.Text = string.Empty;
        }
        public void checkout() // Checkout Method
        {
            if (cart.Count == 0)
            {
                MessageBox.Show("Cart is Empty", "Empty");

            }
            //If the Cart is empty, then the the message box should tell the user that when
            // they want to checkout.

            else
            {
                //This is the code to get the recipt
                double temptotal = 0;// initialises the subtotal as 0
               
                string receipt = string.Empty;// intitialises the recipt string and makes it empty
                string dateandtime = DateTime.Now.ToString();//Date and time at the moment of purchase is defined
                foreach(Item item in cart)
                {
                    receipt += "\nItem:";
                    receipt += $"\n{item.Iteminfo()}";
                    temptotal += item.Price;
                   
                }
                double total = temptotal * TAX_RATE;// This calculates the tax for each item

                receipt += $"\n\nSubtotal: ${temptotal:F2}"; //Displays subtotal
                receipt += $"\n\nTotal (Added HST): ${total:F2}";//Displays the total after tax
                receipt += $"\n\n: {dateandtime}"; // Displays the date and time.
                MessageBox.Show(receipt, "Receipt");// The message mox shows the receipt containing the items purchased,
                                                    // the price, the subtotal and the final total after tax as well as
                                                    // the date and time of purchase
                cart.Clear();//Clears the cart
                updateTotal();  //Resets the total to 0
            }
        }
        public void showCart()
        {
            if (cart.Count == 0)
            {
                MessageBox.Show("Cart is Empty", "Empty");

            }


            else
            {
                double temptotal = 0;

                string showcart = string.Empty;
                string dateandtime = DateTime.Now.ToString();
                foreach (Item item in cart)
                {
                    showcart += "\nItem:";
                    showcart += $"\n{item.Iteminfo()}";
                    temptotal += item.Price;

                }
                double total = temptotal * TAX_RATE;

                showcart += $"\n\nSubtotal: ${temptotal:F2}";

                
                MessageBox.Show(showcart, "Cart");

            }
        }




      
       public class Item//Class to define the items.
        {
            public string Name;
            public double Price;

            public Item (string name, double price)
            {
                Name = name; //Stores the Name and Price parameters as the string- name and the double price
                Price = price;
            }

            public string Iteminfo()// Stores the Item info 
            {
                return $"{Name} - ${Price:F2}";
            }



        }

        private void label1_Click(object sender, EventArgs e)// Amino Acid Label
        {
           
        }

        private void label4_Click(object sender, EventArgs e) //Preworkout Label
        {

        }

        private void button9_Click(object sender, EventArgs e)//Amino Acid Button
        {
           AddToCart(item[0]);// Calls the addcart method for the first item in the array only
        }
        private void Creatine_Click(object sender, EventArgs e)//Creatine Button
        {
            AddToCart(item[1]);  // Calls the addcart method for the second item in the array only
        }

        private void Preworkout_Click(object sender, EventArgs e) // Preworkout Button
        {
            AddToCart(item[2]);// Calls the addcart method for the third item in the array only
        }

        private void Protein_Click(object sender, EventArgs e)//Protein button
        {
            AddToCart(item[3]);// Calls the addcart method for the fourth item in the array only
        }

        private void Cap_Click(object sender, EventArgs e)//Cap Button
        {
            AddToCart(item[4]);// Calls the addcart method for the fifth item in the array only
        }

        private void Kneesleeves_Click(object sender, EventArgs e)//Kneesleeve Button
        {
            AddToCart(item[5]);// Calls the addcart method for the sixth item in the array only
        }

        private void SleepSupp_Click(object sender, EventArgs e) //Sleep Supplement Button
        {
            AddToCart(item[6]);// Calls the addcart method for the seventh item in the array only
        }

        private void Chocprotein_Click(object sender, EventArgs e)//Chocolate Protein Button
        {
            AddToCart(item[7]);// Calls the addcart method for the eighth item in the array only
        }

        private void button1_Click(object sender, EventArgs e)//Button to clear the cart
        {
            clearcart();
        }

        private void button10_Click(object sender, EventArgs e)//Button to show the cart
        {
            showCart();
        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
