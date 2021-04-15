using System;
using System.Linq;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using Microsoft.Win32;
using System.Windows.Controls;
using System.Windows.Navigation;
using System.Diagnostics;

namespace Wordpad2
{
    public class HyperlinkCreation
    {
		public bool UseShellExecute { get; private set; }

		public void Button_Hyperlink(object sender, RoutedEventArgs e, RichTextBox rtbEditor)
		{
			if (!rtbEditor.Selection.IsEmpty)
			{
				string inputRead = new InputBox("Enter hyperlink:", "Add hyperlink", "").ShowDialog();

				Hyperlink hlink = new Hyperlink();
				TextRange tr = new TextRange(rtbEditor.Selection.Start, rtbEditor.Selection.End);

				try
				{
					hlink.NavigateUri = new Uri(inputRead);
					hlink = new Hyperlink(tr.Start, tr.End);
					hlink.IsEnabled = true;
					hlink.NavigateUri = new Uri(inputRead);
					hlink.IsEnabled = true;
					hlink.RequestNavigate += (sender, e) =>
					{
						Hyperlink_RequestNavigate(sender, e);
					};
					hlink.IsEnabled = true;
					
					MessageBox.Show(Convert.ToString(hlink.IsEnabled));
					 
				}
				catch (Exception exception)
				{
					MessageBox.Show(exception.Message);
					
				}

			}
		}

		private void Hyperlink_RequestNavigate(object sender, RequestNavigateEventArgs e)
		{
			try
			{
				Process pro = new Process();
				UseShellExecute = true;
				pro.StartInfo.FileName = "C:\\Program Files (x86)\\Google\\Chrome\\Application\\chrome.exe";
				pro.StartInfo.Arguments = e.Uri.AbsoluteUri;
				pro.Start();
				e.Handled = true;
			}
			catch (Exception exception)
			{
				MessageBox.Show(exception.Message);
			}
		}
	}
}
