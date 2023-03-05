using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Exam1.Core;

namespace Exam1
{
    public partial class Form1 : Form
    {
        private List<clsListsItem> tlist = new List<clsListsItem>();

        long[] ArrayList;

        public Form1()
        {
            ArrayList = new long[30];
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            buttonSave.Enabled = false;
            buttonSort.Enabled = false;
            button1.Enabled = false;
            button2.Enabled = false;
            buttonSearch.Enabled = false;
            pictureBox1.AllowDrop = true;
            button2.AllowDrop = true;
            buttonSave.Enabled = false;        
        }

        private void pictureBox1_DragDrop(object sender, DragEventArgs e)
        {
            listBox1.Items.RemoveAt(listBox1.SelectedIndex);
            listBox2.Items.RemoveAt(listBox2.SelectedIndex);
            listBox3.Items.RemoveAt(listBox3.SelectedIndex);
        }

        private void pictureBox1_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            listBox2.Items.Clear();
            listBox3.Items.Clear();
            MessageBox.Show("all have been deleted");
        }                                                                   
        private void listBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (listBox1.Items.Count > 0)
                listBox1.DoDragDrop(listBox1.Text, DragDropEffects.Move);
        }
        private void buttonSort_Click(object sender, EventArgs e)
        {
            clsSortFunctions sf = new clsSortFunctions();
            long[] IDs = new long[listBox1.Items.Count];
            long index = 0;
            foreach (clsListsItem item in tlist)
            {
                IDs[index] = item.getID();
                index++;
            }

            //Set the data into the class
            sf.setData(IDs);

            //sf.sort(SortFunctions.Bubble); //using Bubble Sort
            sf.sort(SortFunctions.Quick); //using Quick Sort

            //get the sorted data from the class
            long[] sortedIDs = sf.getData();

            //Clear all lists for the new sorted items
            listBox1.Items.Clear();
            listBox2.Items.Clear();
            listBox3.Items.Clear();

            foreach (long item in sortedIDs)
            {
                long x1 = long.Parse(tlist.Where(x => x.getID() == item).Select(x => x.getID()).FirstOrDefault().ToString());
                string x2 = tlist.Where(x => x.getID() == item).Select(x => x.getName()).FirstOrDefault().ToString();
                string x3 = tlist.Where(x => x.getID() == item).Select(x => x.getLName()).FirstOrDefault().ToString();

                listBox1.Items.Add(x1.ToString());
                listBox2.Items.Add(x2);
                listBox3.Items.Add(x3);
            }       
        }
        private void ds(object sender, EventArgs e)
        {
            if (listBox1.Text == " ")
            {
                button2.Enabled = false;
                button1.Enabled = false;
                buttonSort.Enabled = false;
                buttonSave.Enabled = false;
                buttonSearch.Enabled = false;
                
            }
            else
            {
                button2.Enabled = true;
                button1.Enabled = true;
                buttonSort.Enabled = true;
                buttonSave.Enabled = true;
                buttonSearch.Enabled = true;
               


            }
        }
        private void buttonExit_Click(object sender, EventArgs e)
        {
            DialogResult keyPressed;
            keyPressed = MessageBox.Show(
            "Do you want to Exit", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (keyPressed == DialogResult.Yes)
            {
                MessageBox.Show("Thank you for trying me");
                System.Windows.Forms.Application.Exit();  
            }
            else if (keyPressed == DialogResult.No)
            {        
            }      
        }

        private void buttonAddInfo_Click(object sender, EventArgs e)
        {  
            if (textBoxSNumber.Text == "")
            {
                MessageBox.Show("please enter a value into textBox");
            }
            else
            {                               
                bool duplicate = false;
                for (int i = 0; i < listBox1.Items.Count; i++)
                {
                    if (textBoxSNumber.Text == listBox1.Items[i].ToString())
                    {
                        duplicate = true;
                        MessageBox.Show("this item is already existed");
                    }
                }
                if (duplicate == false)
                {
                    clsListsItem item = new clsListsItem(long.Parse(textBoxSNumber.Text), textBoxSName.Text, textBoxSLN.Text);
                    tlist.Add(item);

                    long arrayValueSize = long.Parse(labelCount.Text);
                    ArrayList[arrayValueSize] = (long.Parse(textBoxSNumber.Text));
                    arrayValueSize++;
                    labelCount.Text = arrayValueSize.ToString();

                    if (arrayValueSize > 1)
                    {
                        buttonSort.Enabled = true;
                        if (arrayValueSize == ArrayList.Length)
                        {
                            buttonAddInfo.Enabled = false;
                        }
                    }

                    listBox1.Items.Add(textBoxSNumber.Text);
                    listBox2.Items.Add(textBoxSName.Text);
                    listBox3.Items.Add(textBoxSLN.Text);
                    textBoxSNumber.Text = "";
                    textBoxSName.Text = "";
                    textBoxSLN.Text = "";
                }
            }
        }
        private void listBox2_MouseDown(object sender, MouseEventArgs e)
        {
            if (listBox2.Items.Count > 0)
                listBox2.DoDragDrop(listBox2.Text, DragDropEffects.Move);
        }

        private void listBox3_MouseDown(object sender, MouseEventArgs e)
        {
            if (listBox3.Items.Count > 0)
                listBox3.DoDragDrop(listBox3.Text, DragDropEffects.Move);
        }

        private void button2_DragDrop(object sender, DragEventArgs e)
        {

        }

       private void button2_DragEnter(object sender, DragEventArgs e)
        { 
            e.Effect = DragDropEffects.Move;
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            SaveFileDialog dlg = new SaveFileDialog();
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                StreamWriter write = new StreamWriter(dlg.FileName);
                for (int i = 0; i < listBox1.Items.Count; i++)
                {
                    write.WriteLine((string)listBox1.Items[i]);
                    //write a line for the first name
                    write.WriteLine((string)listBox2.Items[i]);
                    //write a line for the last name
                    write.WriteLine((string)listBox3.Items[i]);
                }

                //write 11 0's to finish the file
                write.WriteLine("00000000000");
                write.Close();
            }
            dlg.Dispose();
        }

        private void buttonLoad_Click(object sender, EventArgs e)
        {
            if (txtPath.Text == " ")
            {
                buttonLoad.Enabled = true;
            }
            else
            {
                buttonLoad.Enabled = false;
                string[] lines = System.IO.File.ReadAllLines(txtPath.Text.Trim());
                long x = 0;
                while (lines[x] != "00000000000")
                {
                    listBox1.Items.Add((lines[x]));
                    listBox2.Items.Add(lines[x + 1]);
                    listBox3.Items.Add(lines[x + 2]);
                    x = x + 3;
                }
                buttonSearch.Enabled = true;
                buttonSort.Enabled = false;
                button1.Enabled = true;
                button2.Enabled = true;
                buttonSave.Enabled = true;
                buttonAddInfo.Enabled = false;
            }
        }

        private void btnPath_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog op = new OpenFileDialog();

                if (op.ShowDialog() == DialogResult.OK)
                {
                    txtPath.Text = op.FileName;
                }
            }
            catch { }
        }
        private void buttonSearch_Click(object sender, EventArgs e)
        {            
            string findID = textBoxSearch.Text;
            if (radioButton1.Checked)
            {
                long[] lBox = new long[listBox1.Items.Count];
                for (int i =0; i< listBox1.Items.Count; i++)
                {
                    lBox[i] = long.Parse(listBox1.Items[i].ToString());
                }                  
                clsCoreSearchFunctions csf = new clsCoreSearchFunctions(lBox);
                long x = long.Parse(findID);
                long pos = csf.BinarySearch(x); //without recursive
                //int pos = csf.BinarySearch(x, 0, lBox.Length); //with recursive
                
                if (pos != -1)
                {
                    MessageBox.Show(findID + " on location number " + pos);
                    listBox1.SelectedItem = findID;
                }
                else //pos = -1
                {
                    MessageBox.Show("Item NOT Found");
                }
                textBoxSearch.Clear();
            } else if (radioButton2.Checked) {
                // search for first name
                string[] lBox = listBox2.Items.OfType<string>().ToArray();
                clsCoreSearchFunctions csf = new clsCoreSearchFunctions(lBox);


                long OK = csf.LinerSearch(findID);
                if (OK != -1)
                {
                    MessageBox.Show(findID + " on location number " + OK);
                    listBox2.SelectedItem = findID;
                }
                else
                {
                    MessageBox.Show("Item NOT Found");
                }
                textBoxSearch.Clear();
            }
            else if (radioButton3.Checked)
            {
                // search for last name
                string[] lBox = listBox3.Items.OfType<string>().ToArray();
                clsCoreSearchFunctions csf = new clsCoreSearchFunctions(lBox);


                long OK = csf.LinerSearch(findID);
                if (OK != -1)
                {
                    MessageBox.Show(findID + " on location number " + OK);
                    listBox3.SelectedItem = findID;
                }
                else
                {
                    MessageBox.Show("Item NOT Found");
                }
                textBoxSearch.Clear();
            }
            else
            {
                MessageBox.Show("please choose how to searchch by clicking a button");
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex ==-1)
            {
               MessageBox.Show("please selest an item(s)");
            }
            else
            {
               int items = listBox1.SelectedIndex;
                    listBox1.Items.RemoveAt(items);
                    listBox2.Items.RemoveAt(items);
                    listBox3.Items.RemoveAt(items);
                listBox1.Update();              
            }        
        }
    }
}
