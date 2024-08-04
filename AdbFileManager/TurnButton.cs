using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
public class VerticalButton : Button {
    public string VerticalText { get; set; }
    protected override void OnPaint(PaintEventArgs pe) {
        base.OnPaint(pe);

        StringFormat stringFormat = new StringFormat();
        stringFormat.FormatFlags = StringFormatFlags.DirectionVertical;
        SolidBrush solidBrush = new SolidBrush(this.ForeColor);

        stringFormat.Alignment = StringAlignment.Center;
        stringFormat.LineAlignment = StringAlignment.Center;

        pe.Graphics.DrawString(VerticalText, this.Font, solidBrush, new Rectangle(0, 0, Width, Height), stringFormat);
    }
}