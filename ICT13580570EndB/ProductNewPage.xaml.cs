using System;
using System.Collections.Generic;
using ICT13580570EndB.Models;
using Xamarin.Forms;

namespace ICT13580570EndB
{
    public partial class ProductNewPage : ContentPage
    {
        private Product product;
        public ProductNewPage(Product product = null)
        {
            InitializeComponent();
            this.product = product;
            titleLabel.Text = product == null ? "เพิ่มข้อมูลรถ" : "แก้ไขข้อมูลรถ";

            typePicker.Items.Add("รถตู้");
            typePicker.Items.Add("รถครอบครัว");
            brandPicker.Items.Add("TOYOTA");
            brandPicker.Items.Add("HONDA");
            cityPicker.Items.Add("เพชรบุรี");
            cityPicker.Items.Add("กรุงเทพมหานคร");
            colorPicker.Items.Add("ขาว");
            colorPicker.Items.Add("ดำ");

            myStepper.ValueChanged += MyStepper_ValueChanged;
            mySlider.ValueChanged += MySlider_ValueChanged;

            saveButton.Clicked += SaveButton_Clicked;

            if(product != null)
            {
                typePicker.SelectedItem = product.TypeCar;
                brandPicker.SelectedItem = product.Brand;
                classEntry.Text = product.Brand;
                yearLabel.Text = product.Year;
                numberLabel.Text = product.Number.ToString();
                colorPicker.SelectedItem = product.Color;

                detailEditor.Text = product.DetailCar;
                priceEntry.Text = product.Price;
                cityPicker.SelectedItem = product.City;
                phoneEntry.Text = product.Phone;


            }
        }

        async void SaveButton_Clicked(object sender, EventArgs e)
        {
            var isOk = await DisplayAlert("ยืนยัน", "คุณต้องการบันทึกข้อมูลนี้ใช่หรือไม่", "ใช่", "ยกเลิก");
            if(isOk){

                var detail = new Product();
                if(product==null){
                    product = new Product();
                    product.TypeCar = typePicker.SelectedItem.ToString();
                    product.Brand = brandPicker.SelectedItem.ToString();
                    product.Class = classEntry.Text;
                    product.Year = yearLabel.Text;
                    product.Number = decimal.Parse(numberLabel.Text);
                    product.Color = colorPicker.SelectedItem.ToString();
                    product.Status = statusEntry.IsToggled;
                    product.DetailCar = detailEditor.Text;
                    product.Price = priceEntry.Text;
                    product.City = cityPicker.SelectedItem.ToString();
                    product.Phone = phoneEntry.Text;

                    var id = App.DbHelper.AddProduct(product);
					await DisplayAlert("บันทึกสำเร็จ", "รหัสสินค้าของท่านคือ #" + id, "ตกลง");
                }
                else{
					product = new Product();
					product.TypeCar = typePicker.SelectedItem.ToString();
					product.Brand = brandPicker.SelectedItem.ToString();
					product.Class = classEntry.Text;
					product.Year = yearLabel.Text;
					product.Number = decimal.Parse(numberLabel.Text);
					product.Color = colorPicker.SelectedItem.ToString();
					product.Status = statusEntry.IsToggled;
					product.DetailCar = detailEditor.Text;
					product.Price = priceEntry.Text;
					product.City = cityPicker.SelectedItem.ToString();
					product.Phone = phoneEntry.Text;

                    var id = App.DbHelper.UpdateProduct(product);
					await DisplayAlert("บันทึกสำเร็จ", "รหัสสินค้าของท่านคือ #" + id, "ตกลง");
                }
                await Navigation.PopModalAsync();
            }
        }

        void MyStepper_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            int value = (int)e.NewValue;
            yearLabel.Text = value.ToString();
        }

        void MySlider_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            int value = (int)e.NewValue;
            numberLabel.Text = value.ToString();
        }
    }
}
