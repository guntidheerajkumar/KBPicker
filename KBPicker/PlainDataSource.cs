//MIT License

//Copyright(c) 2016 Dheeraj Kumar Gunti

//Permission is hereby granted, free of charge, to any person obtaining a copy
//of this software and associated documentation files (the "Software"), to deal
//in the Software without restriction, including without limitation the rights
//to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
//copies of the Software, and to permit persons to whom the Software is
//furnished to do so, subject to the following conditions:

//The above copyright notice and this permission notice shall be included in all
//copies or substantial portions of the Software.

//THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
//IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
//FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
//AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
//LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
//OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
//SOFTWARE.

using System;
using UIKit;
using System.Collections.Generic;
using Foundation;

namespace KBPicker
{
    /// <summary>
    /// UITableDatasource for Lookup
    /// </summary>
    /// <seealso cref="UIKit.UITableViewSource" />
    public class PlainDataSource : UITableViewSource
	{
		protected List<string> dataItems;
		public event EventHandler<EventArgs> ValueSelected;
		protected string cellIdentifier = "TableCell";
		public UIColor TextColor;
		public UIFont TextFont;
		private int selectedIndex = 0;

		public string SelectedItem {
			get { return this.dataItems [this.selectedIndex]; }
		}

		public PlainDataSource (List<string> ListItems)
		{
			dataItems = ListItems;
		}

        public override nint RowsInSection (UITableView tableview, nint section)
		{
			return dataItems.Count;
		}

		public override nfloat GetHeightForRow (UITableView tableView, NSIndexPath indexPath)
		{
			return 30;
		}

		public override UITableViewCell GetCell (UITableView tableView, NSIndexPath indexPath)
		{
			UITableViewCell cell = tableView.DequeueReusableCell (cellIdentifier);
			if (cell == null)
				cell = new UITableViewCell (UITableViewCellStyle.Default, cellIdentifier);
			cell.TextLabel.Text = dataItems [indexPath.Row];
			if (TextFont == null) {
				cell.TextLabel.Font = UIFont.SystemFontOfSize (14);
				cell.TextLabel.Font = UIFont.FromName ("AvenirNext-Regular", 14);
			} else {
				cell.TextLabel.Font = UIFont.SystemFontOfSize (14);
				cell.TextLabel.Font = TextFont;
			}
			cell.BackgroundColor = UIColor.Clear;
			if (TextColor == null) {
				cell.TextLabel.TextColor = UIColor.DarkGray;
			} else {
				cell.TextLabel.TextColor = TextColor;
			}
			cell.TextLabel.BackgroundColor = UIColor.Clear;
			return cell;
		}

		public override void RowSelected (UITableView tableView, NSIndexPath indexPath)
		{
			this.selectedIndex = indexPath.Row;
			if (this.ValueSelected != null) {
				this.ValueSelected (this, new EventArgs ());
			}
		}
	}
}

