using System;
using UIKit;

namespace DiarioApp
{
    public class PickerModel : UIPickerViewModel
    {
        public PickerModel()
        {
        }

        public string[] emocion { get; set; }
        private UILabel emocioneslabel;
        public string selectedEmocion { get; set; }


        public PickerModel(UILabel emocioneslabel, string[] emocion)
        {
            this.emocioneslabel = emocioneslabel;
            this.emocion = emocion;
        }

        public override nint GetComponentCount(UIPickerView pickerView)
        {
            return 1;
        }

        public override nint GetRowsInComponent(UIPickerView pickerView, nint component)
        {
            return emocion.Length;
        }

        public override string GetTitle(UIPickerView pickerView, nint row, nint component)
        {
            if (component == 0)
                return emocion[row];
            else
                return row.ToString();
        }

        public override void Selected(UIPickerView pickerView, nint row, nint component)
        {
            selectedEmocion = emocion[(int)row]; ;
            emocioneslabel.Text =
                              $"Tu dia fue: {emocion[pickerView.SelectedRowInComponent(0)]}"; //,\n they are number {pickerView.SelectedRowInComponent(1)}";
        }



        /*
        public override nfloat GetComponentWidth(UIPickerView picker, nint component)
        {
            if (component == 0)
                return 240f;
            else
                return 40f;
        }

        public override nfloat GetRowHeight(UIPickerView picker, nint component)
        {
            return 40f;
        }
        */
    }
}
