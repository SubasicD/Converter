using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Globalization;                         // Used to check if inputs are Hex
using System.Text.RegularExpressions;               // Used to check if input is Binary

namespace BinaryHexConverter
{
    /// <summary>
    /// Integer,Binary and Hex Converter 
    /// By Damir Subasic
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Convert_Button_Click(object sender, RoutedEventArgs e)
        {


        }
                                                                                   // Base 10 is Decimal
        private void Decimal_In_TextChanged(object sender, TextChangedEventArgs e) // if text is changed do this
        {
            if (Decimal_In.Text.Length == 0)                                       // if Empty
            {
                Clear_Outputs();
            }
            if (Decimal_In.Text.Length != 0)                                       // if Not Empty
            {
                int value;
                if (int.TryParse(Decimal_In.Text, out value))                          // if all values are ints
                {
                    Warning_Label.Content = "";                                        // Clears warning label
                    String Input = Convert.ToString(Decimal_In.Text);                  // Convert input to string from char first
                    Decimal_Out.Text = Decimal_In.Text;                                // Decimal Output = Decimal Input
                    Binary_Out.Text = Convert.ToString(Convert.ToInt32(Input, 10), 2); // Convert from base 10 to 2
                    Hex_Out.Text = Convert.ToString(Convert.ToInt32(Input, 10), 16);   // Convert from base 10 to 16
                    Nibble_Maker();                                                    // Outputs the Nibbles
                }
                else
                {
                    Warning_Label.Content = "Warning: Integer input is not an integer";
                }
            }
            // Multiple input conditions
            Multi_Input_Warning();
        }



        private void Binary_In_TextChanged(object sender, TextChangedEventArgs e)
        {

            if (Regex.IsMatch(Binary_In.Text, "^[01]+$"))                              // checks if input only has 1's and 0s
            {
                if (Binary_In.Text.Length == 0)                                        // if Empty
                {
                    Clear_Outputs();
                }
                if (Binary_In.Text.Length != 0)                                        // if Not Empty
                {
                    Warning_Label.Content = "";                                        // Clears warning label
                    String Input = Convert.ToString(Binary_In.Text);                   // Convert input to string from char first
                    Decimal_Out.Text = Convert.ToString(Convert.ToInt32(Input, 2), 10);// Convert from base 2 to 10
                    Binary_Out.Text = Binary_In.Text;                                  // Binary Input = Output
                    Hex_Out.Text = Convert.ToString(Convert.ToInt32(Input, 2), 16);    // Convert from base 2 to 16
                    Nibble_Maker();                                                    // Outputs the Nibbles
                }
                // Multiple input conditions
                Multi_Input_Warning();
            }
            else
            {
                Warning_Label.Content = "Warning: Binary input is not a Binary Number";
            }
        }

        private void Hex_In_TextChanged(object sender, TextChangedEventArgs e)
        {
            int value;                                                                 // Parses input for Hex values
            bool valid = int.TryParse(Hex_In.Text, NumberStyles.HexNumber, CultureInfo.InvariantCulture, out value);
            if (valid)
            {
                if (Hex_In.Text.Length == 0)                                           // if Empty
                {
                    Clear_Outputs();
                }
                if (Hex_In.Text.Length != 0)                                            // if Not Empty
                {
                    Warning_Label.Content = "";                                         // Clears warning label
                    String Input = Convert.ToString(Hex_In.Text);                       // Convert input to string from char first
                    Decimal_Out.Text = Convert.ToString(Convert.ToInt32(Input, 16), 10);// Convert from base 16 to 10
                    Binary_Out.Text = Convert.ToString(Convert.ToInt32(Input, 16), 2);  // Convert from base 16 to 2
                    Hex_Out.Text = Hex_In.Text;                                         // Hex Input = Output
                    Nibble_Maker();                                                    // Outputs the Nibbles

                }
                // Multiple input conditions
                Multi_Input_Warning();
            }
            else
            {
                Warning_Label.Content = "Warning: Hex input is not a Hexadecimal Number";
            }
        }

        private void ListBoxItem_Selected(object sender, RoutedEventArgs e)
        {

        }

        private void History_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Nibbles_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        public void Multi_Input_Warning()
        {
            if (((Decimal_In.Text.Length != 0) && (Binary_In.Text.Length != 0)) ||
                    ((Decimal_In.Text.Length != 0) && (Hex_In.Text.Length != 0)) ||
                    ((Binary_In.Text.Length != 0) && (Hex_In.Text.Length != 0)))
            {
                Clear_Outputs();
                Warning_Label.Content = "Warning: Please only input 1 value at a time";
            }

        }

        public void Clear_Outputs()
        {
            Decimal_Out.Text = "";
            Binary_Out.Text = "";                                              // Clear all outputs
            Hex_Out.Text = "";
            Nibbles.Text = "";
        }

        public void Nibble_Maker()
        {
            if (Binary_Out.Text.Length > 4)                                    // Creates Nibbles
            {
                string nib = "";
                char[] charArray = Binary_Out.Text.ToCharArray();              // reverses the string
                Array.Reverse(charArray);
                string rev = new string(charArray);
                int j = 1;
                for (int i = 0; i < rev.Length; i++)
                {
                    nib = nib + rev[i];
                    if (j % 4 == 0)                                            // adds spaces ever 4 digits
                    {
                        nib = nib + " ";
                    }
                    j++;
                }

                char[] charArray2 = nib.ToCharArray();                          // reverses the string
                Array.Reverse(charArray2);                                      // back to normal
                string forwards = new string(charArray2);                       // sets output
                Nibbles.Text = forwards;
            }
        }


    }
}
