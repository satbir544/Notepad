using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
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
using Microsoft.Win32;

/*
 *  FILE            : MainWindow.xaml.cs
 *  PROJECT         : Assignment 02
 *  PROGRAMMER      : Satbir Singh
 *  FIRST VERSION	: 2020-09-17
 *  DESCRIPTION     : The functions in this file are used to make a text editor which mimics the functionality of notepad.
*/

namespace Assignment02
{
    /*
    *   NAME : MainWindow
    *   PURPOSE : This class has been created to model the behavior of a text editor app. It has methods for a button click and for
    *       keeping track of the amount of characters entered. It also has members to keep track of the text entered by the user
    *       and to see if the user clicked the yes button when prompted.
    */
    public partial class MainWindow : Window
    {
        private static string text = "";
        private static bool clickedYes = false;

        /*
	    *	METHOD	    : MainWindow
	    *	DESCRIPTION	: constructor for initializing the components of the main window
	    *	PARAMETERS	: none
	    *	RETURNS		: none
	    */
        public MainWindow()
        {
            InitializeComponent();
        }

        /*
	    *	METHOD	    : CommandBinding_CanExecute
	    *	DESCRIPTION	: makes the button able to be clicked
	    *	PARAMETERS	: object sender: contains a reference to the object that raised the event
	    *	              CanExecuteRoutedEventArgs e: provides data for the CanExecute and PreviewCanExecute routed events
	    *	RETURNS		: none
	    */
        private void CommandBinding_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        /*
	    *	METHOD	    : MsgNo_Click
	    *	DESCRIPTION	: Displays a save message with the options of yes or cancel
	    *	PARAMETERS	: object sender: contains a reference to the object that raised the event
	    *	              RoutedEventArgs e: contains state information and event data associated with a routed event
	    *	RETURNS		: bool: true if the user clicks the no button, false otherwise
	    */
        private bool MsgNo_Click(object sender, RoutedEventArgs e)
        {
            bool clickedNo = false;

            MessageBoxResult mbResult = MessageBox.Show("Would you like to save?", "Save Message", MessageBoxButton.YesNoCancel);

            if (mbResult == MessageBoxResult.Cancel)
            {
                CancelEventArgs c = new CancelEventArgs();
                c.Cancel = true;
            }
            else if (mbResult == MessageBoxResult.Yes)
            {
                clickedYes = true;
                MenuSave_Click(sender, e);
            }
            else
            {
                clickedNo = true;
            }

            return clickedNo;
        }

        /*
	    *	METHOD	    : MenuNew_Click
	    *	DESCRIPTION	: Resets the content in the TextBox when the 'New' menu item is clicked
	    *	PARAMETERS	: object sender: contains a reference to the object that raised the event
	    *	              RoutedEventArgs e: contains state information and event data associated with a routed event
	    *	RETURNS		: none
	    */
        private void MenuNew_Click(object sender, RoutedEventArgs e)
        {
            if (text == tx1.Text || MsgNo_Click(sender, e) == true || clickedYes == true)
            {
                tx1.Text = "";
                text = "";
                clickedYes = false;
            }
        }

        /*
	    *	METHOD	    : MenuOpen_Click
	    *	DESCRIPTION	: Opens a new file when the 'Open' menu item is clicked and inputs the content of the selected file into the TextBox
	    *	PARAMETERS	: object sender: contains a reference to the object that raised the event
	    *	              RoutedEventArgs e: contains state information and event data associated with a routed event
	    *	RETURNS		: none
	    */
        private void MenuOpen_Click(object sender, RoutedEventArgs e)
        {
            if (text == tx1.Text || MsgNo_Click(sender, e) == true || clickedYes == true)
            {
                OpenFileDialog openDlg = new OpenFileDialog();
                if (openDlg.ShowDialog() == true)
                {
                    tx1.Text = File.ReadAllText(openDlg.FileName);
                    text = tx1.Text;
                    clickedYes = false;
                }
            }
        }

        /*
	    *	METHOD	    : MenuSave_Click
	    *	DESCRIPTION	: Opens the save file dialog when the 'Save As' menu item is clicked
	    *	PARAMETERS	: object sender: contains a reference to the object that raised the event
	    *	              RoutedEventArgs e: contains state information and event data associated with a routed event
	    *	RETURNS		: none
	    */
        private void MenuSave_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveDlg = new SaveFileDialog();
            saveDlg.Filter = "Text file(*.txt)|*.txt";

            if (saveDlg.ShowDialog() == true)
            {
                File.WriteAllText(saveDlg.FileName, tx1.Text);
                text = tx1.Text;
            }
            else
            {
                clickedYes = false;
            }
        }

        /*
	    *	METHOD	    : MenuExit_Click
	    *	DESCRIPTION	: This method closes the application when the user clicks the 'Close' menu item. If there is 
	    *                 unsaved text, when choosing 'Close', the user can Save and Close, Close without Saving,
	    *                 or Cancel the Close operation
	    *	PARAMETERS	: object sender: contains a reference to the object that raised the event
	    *	              RoutedEventArgs e: contains state information and event data associated with a routed event
	    *	RETURNS		: none
	    */
        private void MenuExit_Click(object sender, RoutedEventArgs e)
        {
            if (text == tx1.Text || MsgNo_Click(sender, e) == true || clickedYes == true)
            {
                this.Close();
            }
        }

        /*
	    *	METHOD	    : MenuAbout_Click
	    *	DESCRIPTION	: Opens the About window in the center of the main window
	    *	PARAMETERS	: object sender: contains a reference to the object that raised the event
	    *	              RoutedEventArgs e: contains state information and event data associated with a routed event
	    *	RETURNS		: none
	    */
        private void MenuAbout_Click(object sender, RoutedEventArgs e)
        {
            About aboutBox = new About();
            aboutBox.Owner = this;
            aboutBox.ShowDialog();
        }

        /*
	    *	METHOD	    : Character_Count
	    *	DESCRIPTION	: Keeps count of the entered characters
	    *	PARAMETERS	: none
	    *	RETURNS		: none
	    */
        private void Character_Count()
        {
            int count = tx1.Text.Length;
            countLabel.Content = count.ToString();
        }

        /*
	    *	METHOD	    : Tx1_TextChanged
	    *	DESCRIPTION	: Uses the Character_Count method when the text has been changed
	    *	PARAMETERS	: object sender: contains a reference to the object that raised the event
	    *	              RoutedEventArgs e: contains state information and event data associated with a routed event
	    *	RETURNS		: none
	    */
        private void Tx1_TextChanged(object sender, TextChangedEventArgs e)
        {
            Character_Count();
        }
    }
}
