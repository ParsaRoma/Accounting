﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyContacts
{
    public partial class frm_Add_Edit : Form
    {
        IContactsRepository repository;
        public frm_Add_Edit()
        {
            InitializeComponent();
            repository = new ContactsRepository();
        }

        

        private void frm_Add_Edit_Load(object sender, EventArgs e)
        {
            this.Text = "افزودن شخص جدید";

        }   
            
         bool ValidateInputs()
            {
                
                if (txtName.Text == "")
                {
                        MessageBox.Show("لطفا نام را وارد کنید", "ارور", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;


                }
                if(txtEmail.Text == "")
                {
                    
                    MessageBox.Show("لطفا ایمیل را وارد کنید", "ارور", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                if(txtFamily.Text == "")
                {
                    
                    MessageBox.Show("لطفا نام خانوادگی را وارد کنید", "ارور", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                } 
                if(txtAge.Value == 0)
                { 
                    
                  MessageBox.Show("لطفا سن خود را وارد کنید", "ارور", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }   
                if(txtMobile.Text == "")
                {
                    
                    MessageBox.Show("لطفا شماره همراه خود را وارد کنید", "ارور", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }

                return true;
            }
        

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (ValidateInputs())
            {
                bool isSuccess = repository.Insert(txtName.Text, txtFamily.Text, txtMobile.Text, txtEmail.Text, (int)txtAge.Value, txtAddress.Text);

                if (isSuccess == true)
                {
                    MessageBox.Show("عملیات با موفقیت انجام شد", "موفقیت", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DialogResult= DialogResult.OK;
                }
                else
                {
                    MessageBox.Show("عملیات با شکست مواجه شد", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
