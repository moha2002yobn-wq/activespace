using System;
using System.Drawing;
using System.Windows.Forms;
using ActiveSpaceSystem.CustomItems;

namespace ActiveSpaceSystem.CustomItems
{
    public class TabButton : RoundedButton // يرث من الزر الدائري الذي صنعناه
    {
        private bool _isActive = false;
        public bool IsActive
        {
            get => _isActive;
            set
            {
                _isActive = value;
                // تغيير الألوان بناءً على حالة التنشيط
                this.BackColor = _isActive ? Color.FromArgb(41, 51, 146) : Color.White;
                this.ForeColor = _isActive ? Color.White : Color.Black;
            }
        }
    }
}