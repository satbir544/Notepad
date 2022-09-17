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
using System.Windows.Shapes;

/*
 *  FILE            : About.xaml.cs
 *  PROJECT         : Assignment 02
 *  PROGRAMMER      : Satbir Singh
 *  FIRST VERSION	: 2020-09-17
 *  DESCRIPTION     : The functions in this file initialize the components of the about box.
*/

namespace Assignment02
{
    /*
    *   NAME : About
    *   PURPOSE : This class has been created to model a window for an about page
    */
    public partial class About : Window
    {
        /*
	    *	METHOD	    : About
	    *	DESCRIPTION	: constructor for initializing the components of the About window
	    *	PARAMETERS	: none
	    *	RETURNS		: none
	    */
        public About()
        {
            InitializeComponent();
        }

        /*
	    *	METHOD	    : Button_Click
	    *	DESCRIPTION	: sets the DialogResult to true if the user presses the OK button
	    *	PARAMETERS	: object sender: contains a reference to the object that raised the event
	    *	              RoutedEventArgs e: contains state information and event data associated with a routed event
	    *	RETURNS		: none
	    */
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }
    }
}
