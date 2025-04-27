using System.Drawing;
using System.Windows.Forms;

namespace QuanLyKhoSach
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.Sách = new System.Windows.Forms.TabPage();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtDescription = new System.Windows.Forms.RichTextBox();
            this.Description = new System.Windows.Forms.Label();
            this.txtPrice = new System.Windows.Forms.TextBox();
            this.Price = new System.Windows.Forms.Label();
            this.cbPublisher = new System.Windows.Forms.ComboBox();
            this.NXB = new System.Windows.Forms.Label();
            this.cbCategory = new System.Windows.Forms.ComboBox();
            this.cbAuthor = new System.Windows.Forms.ComboBox();
            this.Category = new System.Windows.Forms.Label();
            this.AuthorName = new System.Windows.Forms.Label();
            this.txtTitle = new System.Windows.Forms.TextBox();
            this.BookName = new System.Windows.Forms.Label();
            this.DeleteBook = new System.Windows.Forms.Button();
            this.EditBook = new System.Windows.Forms.Button();
            this.AddBook = new System.Windows.Forms.Button();
            this.dgvBooks = new System.Windows.Forms.DataGridView();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.dgvCategories = new System.Windows.Forms.DataGridView();
            this.Order = new System.Windows.Forms.TabPage();
            this.panel2 = new System.Windows.Forms.Panel();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.phoneNumber = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.CustomerName = new System.Windows.Forms.Label();
            this.CreatedDay = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.dgvOrders = new System.Windows.Forms.DataGridView();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.dgvImport = new System.Windows.Forms.DataGridView();
            this.tabControl1.SuspendLayout();
            this.Sách.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBooks)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCategories)).BeginInit();
            this.Order.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrders)).BeginInit();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvImport)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.Sách);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.Order);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Location = new System.Drawing.Point(15, 21);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1273, 741);
            this.tabControl1.TabIndex = 0;
            // 
            // Sách
            // 
            this.Sách.Controls.Add(this.panel1);
            this.Sách.Controls.Add(this.dgvBooks);
            this.Sách.Location = new System.Drawing.Point(4, 25);
            this.Sách.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Sách.Name = "Sách";
            this.Sách.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Sách.Size = new System.Drawing.Size(1265, 712);
            this.Sách.TabIndex = 0;
            this.Sách.Text = "Sách";
            this.Sách.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.txtDescription);
            this.panel1.Controls.Add(this.Description);
            this.panel1.Controls.Add(this.txtPrice);
            this.panel1.Controls.Add(this.Price);
            this.panel1.Controls.Add(this.cbPublisher);
            this.panel1.Controls.Add(this.NXB);
            this.panel1.Controls.Add(this.cbCategory);
            this.panel1.Controls.Add(this.cbAuthor);
            this.panel1.Controls.Add(this.Category);
            this.panel1.Controls.Add(this.AuthorName);
            this.panel1.Controls.Add(this.txtTitle);
            this.panel1.Controls.Add(this.BookName);
            this.panel1.Controls.Add(this.DeleteBook);
            this.panel1.Controls.Add(this.EditBook);
            this.panel1.Controls.Add(this.AddBook);
            this.panel1.Location = new System.Drawing.Point(18, 465);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1271, 241);
            this.panel1.TabIndex = 1;
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(800, 104);
            this.txtDescription.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(345, 126);
            this.txtDescription.TabIndex = 15;
            this.txtDescription.Text = "";
            // 
            // Description
            // 
            this.Description.AutoSize = true;
            this.Description.Location = new System.Drawing.Point(739, 104);
            this.Description.Name = "Description";
            this.Description.Size = new System.Drawing.Size(46, 16);
            this.Description.TabIndex = 14;
            this.Description.Text = "Mô Tả";
            // 
            // txtPrice
            // 
            this.txtPrice.Location = new System.Drawing.Point(893, 44);
            this.txtPrice.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.Size = new System.Drawing.Size(186, 22);
            this.txtPrice.TabIndex = 13;
            // 
            // Price
            // 
            this.Price.AutoSize = true;
            this.Price.Location = new System.Drawing.Point(847, 44);
            this.Price.Name = "Price";
            this.Price.Size = new System.Drawing.Size(28, 16);
            this.Price.TabIndex = 12;
            this.Price.Text = "Giá";
            // 
            // cbPublisher
            // 
            this.cbPublisher.FormattingEnabled = true;
            this.cbPublisher.Location = new System.Drawing.Point(476, 104);
            this.cbPublisher.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbPublisher.Name = "cbPublisher";
            this.cbPublisher.Size = new System.Drawing.Size(197, 24);
            this.cbPublisher.TabIndex = 11;
            // 
            // NXB
            // 
            this.NXB.AutoSize = true;
            this.NXB.Location = new System.Drawing.Point(371, 104);
            this.NXB.Name = "NXB";
            this.NXB.Size = new System.Drawing.Size(88, 16);
            this.NXB.TabIndex = 10;
            this.NXB.Text = "Nhà Xuất Bản";
            // 
            // cbCategory
            // 
            this.cbCategory.FormattingEnabled = true;
            this.cbCategory.Location = new System.Drawing.Point(598, 44);
            this.cbCategory.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbCategory.Name = "cbCategory";
            this.cbCategory.Size = new System.Drawing.Size(197, 24);
            this.cbCategory.TabIndex = 9;
            // 
            // cbAuthor
            // 
            this.cbAuthor.FormattingEnabled = true;
            this.cbAuthor.Location = new System.Drawing.Point(127, 104);
            this.cbAuthor.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbAuthor.Name = "cbAuthor";
            this.cbAuthor.Size = new System.Drawing.Size(197, 24);
            this.cbAuthor.TabIndex = 8;
            // 
            // Category
            // 
            this.Category.AutoSize = true;
            this.Category.Location = new System.Drawing.Point(522, 47);
            this.Category.Name = "Category";
            this.Category.Size = new System.Drawing.Size(60, 16);
            this.Category.TabIndex = 7;
            this.Category.Text = "Thể Loại";
            // 
            // AuthorName
            // 
            this.AuthorName.AutoSize = true;
            this.AuthorName.Location = new System.Drawing.Point(44, 107);
            this.AuthorName.Name = "AuthorName";
            this.AuthorName.Size = new System.Drawing.Size(53, 16);
            this.AuthorName.TabIndex = 5;
            this.AuthorName.Text = "Tác giả";
            // 
            // txtTitle
            // 
            this.txtTitle.Location = new System.Drawing.Point(126, 44);
            this.txtTitle.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Size = new System.Drawing.Size(372, 22);
            this.txtTitle.TabIndex = 4;
            // 
            // BookName
            // 
            this.BookName.AutoSize = true;
            this.BookName.Location = new System.Drawing.Point(44, 47);
            this.BookName.Name = "BookName";
            this.BookName.Size = new System.Drawing.Size(65, 16);
            this.BookName.TabIndex = 3;
            this.BookName.Text = "Tên Sách";
            // 
            // DeleteBook
            // 
            this.DeleteBook.BackColor = System.Drawing.Color.Silver;
            this.DeleteBook.Font = new System.Drawing.Font("Segoe UI Light", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DeleteBook.Location = new System.Drawing.Point(330, 182);
            this.DeleteBook.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.DeleteBook.Name = "DeleteBook";
            this.DeleteBook.Size = new System.Drawing.Size(168, 35);
            this.DeleteBook.TabIndex = 2;
            this.DeleteBook.Text = "Xóa";
            this.DeleteBook.UseVisualStyleBackColor = false;
            // 
            // EditBook
            // 
            this.EditBook.BackColor = System.Drawing.Color.Silver;
            this.EditBook.Font = new System.Drawing.Font("Segoe UI Light", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EditBook.Location = new System.Drawing.Point(165, 182);
            this.EditBook.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.EditBook.Name = "EditBook";
            this.EditBook.Size = new System.Drawing.Size(159, 35);
            this.EditBook.TabIndex = 1;
            this.EditBook.Text = "Sửa";
            this.EditBook.UseVisualStyleBackColor = false;
            // 
            // AddBook
            // 
            this.AddBook.BackColor = System.Drawing.Color.Silver;
            this.AddBook.Font = new System.Drawing.Font("Segoe UI Light", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AddBook.Location = new System.Drawing.Point(14, 182);
            this.AddBook.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.AddBook.Name = "AddBook";
            this.AddBook.Size = new System.Drawing.Size(145, 35);
            this.AddBook.TabIndex = 0;
            this.AddBook.Text = "Thêm";
            this.AddBook.UseVisualStyleBackColor = false;
            // 
            // dgvBooks
            // 
            this.dgvBooks.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBooks.Location = new System.Drawing.Point(18, 4);
            this.dgvBooks.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgvBooks.Name = "dgvBooks";
            this.dgvBooks.RowHeadersWidth = 51;
            this.dgvBooks.Size = new System.Drawing.Size(1241, 457);
            this.dgvBooks.TabIndex = 0;
            this.dgvBooks.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvBooks_CellDoubleClick);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.label1);
            this.tabPage2.Controls.Add(this.textBox1);
            this.tabPage2.Controls.Add(this.dgvCategories);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPage2.Size = new System.Drawing.Size(1265, 712);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Loại Sách";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(65, 507);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 16);
            this.label1.TabIndex = 6;
            this.label1.Text = "Tác giả";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(135, 504);
            this.textBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(372, 22);
            this.textBox1.TabIndex = 5;
            // 
            // dgvCategories
            // 
            this.dgvCategories.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCategories.Location = new System.Drawing.Point(18, 4);
            this.dgvCategories.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgvCategories.Name = "dgvCategories";
            this.dgvCategories.RowHeadersWidth = 51;
            this.dgvCategories.Size = new System.Drawing.Size(1241, 457);
            this.dgvCategories.TabIndex = 1;
            // 
            // Order
            // 
            this.Order.Controls.Add(this.panel2);
            this.Order.Controls.Add(this.dgvOrders);
            this.Order.Location = new System.Drawing.Point(4, 25);
            this.Order.Name = "Order";
            this.Order.Padding = new System.Windows.Forms.Padding(3);
            this.Order.Size = new System.Drawing.Size(1265, 712);
            this.Order.TabIndex = 2;
            this.Order.Text = "Đơn hàng";
            this.Order.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.textBox3);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.textBox2);
            this.panel2.Controls.Add(this.phoneNumber);
            this.panel2.Controls.Add(this.dateTimePicker1);
            this.panel2.Controls.Add(this.textBox4);
            this.panel2.Controls.Add(this.CustomerName);
            this.panel2.Controls.Add(this.CreatedDay);
            this.panel2.Controls.Add(this.button1);
            this.panel2.Controls.Add(this.button2);
            this.panel2.Controls.Add(this.button3);
            this.panel2.Location = new System.Drawing.Point(-3, 466);
            this.panel2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1271, 241);
            this.panel2.TabIndex = 3;
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(518, 124);
            this.textBox3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(344, 22);
            this.textBox3.TabIndex = 22;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(435, 124);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 16);
            this.label2.TabIndex = 21;
            this.label2.Text = "Địa chỉ giao";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(508, 46);
            this.textBox2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(344, 22);
            this.textBox2.TabIndex = 20;
            // 
            // phoneNumber
            // 
            this.phoneNumber.AutoSize = true;
            this.phoneNumber.Location = new System.Drawing.Point(435, 46);
            this.phoneNumber.Name = "phoneNumber";
            this.phoneNumber.Size = new System.Drawing.Size(67, 16);
            this.phoneNumber.TabIndex = 19;
            this.phoneNumber.Text = "Sdt Khách";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(129, 52);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(200, 22);
            this.dateTimePicker1.TabIndex = 18;
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(129, 124);
            this.textBox4.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(224, 22);
            this.textBox4.TabIndex = 17;
            // 
            // CustomerName
            // 
            this.CustomerName.AutoSize = true;
            this.CustomerName.Location = new System.Drawing.Point(20, 124);
            this.CustomerName.Name = "CustomerName";
            this.CustomerName.Size = new System.Drawing.Size(103, 16);
            this.CustomerName.TabIndex = 16;
            this.CustomerName.Text = "Tên khách hàng";
            // 
            // CreatedDay
            // 
            this.CreatedDay.AutoSize = true;
            this.CreatedDay.Location = new System.Drawing.Point(20, 52);
            this.CreatedDay.Name = "CreatedDay";
            this.CreatedDay.Size = new System.Drawing.Size(69, 16);
            this.CreatedDay.TabIndex = 3;
            this.CreatedDay.Text = "Ngày Lập ";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Silver;
            this.button1.Font = new System.Drawing.Font("Segoe UI Light", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(330, 182);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(168, 35);
            this.button1.TabIndex = 2;
            this.button1.Text = "Xóa";
            this.button1.UseVisualStyleBackColor = false;
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.Silver;
            this.button2.Font = new System.Drawing.Font("Segoe UI Light", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(165, 182);
            this.button2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(159, 35);
            this.button2.TabIndex = 1;
            this.button2.Text = "Sửa";
            this.button2.UseVisualStyleBackColor = false;
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.Silver;
            this.button3.Font = new System.Drawing.Font("Segoe UI Light", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.Location = new System.Drawing.Point(14, 182);
            this.button3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(145, 35);
            this.button3.TabIndex = 0;
            this.button3.Text = "Thêm";
            this.button3.UseVisualStyleBackColor = false;
            // 
            // dgvOrders
            // 
            this.dgvOrders.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvOrders.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOrders.Location = new System.Drawing.Point(-3, 5);
            this.dgvOrders.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgvOrders.Name = "dgvOrders";
            this.dgvOrders.RowHeadersWidth = 51;
            this.dgvOrders.Size = new System.Drawing.Size(1241, 457);
            this.dgvOrders.TabIndex = 2;
            this.dgvOrders.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvOrders_CellContentDoubleClick);
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.textBox6);
            this.tabPage3.Controls.Add(this.label4);
            this.tabPage3.Controls.Add(this.dateTimePicker2);
            this.tabPage3.Controls.Add(this.label6);
            this.tabPage3.Controls.Add(this.button4);
            this.tabPage3.Controls.Add(this.button5);
            this.tabPage3.Controls.Add(this.button6);
            this.tabPage3.Controls.Add(this.dgvImport);
            this.tabPage3.Location = new System.Drawing.Point(4, 25);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(1265, 712);
            this.tabPage3.TabIndex = 3;
            this.tabPage3.Text = "Nhập Sách";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // textBox6
            // 
            this.textBox6.Location = new System.Drawing.Point(570, 531);
            this.textBox6.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new System.Drawing.Size(344, 22);
            this.textBox6.TabIndex = 31;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(450, 531);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(114, 16);
            this.label4.TabIndex = 30;
            this.label4.Text = "Tên nhà cung cấp";
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.Location = new System.Drawing.Point(141, 529);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(200, 22);
            this.dateTimePicker2.TabIndex = 29;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(32, 529);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(69, 16);
            this.label6.TabIndex = 26;
            this.label6.Text = "Ngày Lập ";
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.Silver;
            this.button4.Font = new System.Drawing.Font("Segoe UI Light", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button4.Location = new System.Drawing.Point(342, 659);
            this.button4.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(168, 35);
            this.button4.TabIndex = 25;
            this.button4.Text = "Xóa";
            this.button4.UseVisualStyleBackColor = false;
            // 
            // button5
            // 
            this.button5.BackColor = System.Drawing.Color.Silver;
            this.button5.Font = new System.Drawing.Font("Segoe UI Light", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button5.Location = new System.Drawing.Point(177, 659);
            this.button5.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(159, 35);
            this.button5.TabIndex = 24;
            this.button5.Text = "Sửa";
            this.button5.UseVisualStyleBackColor = false;
            // 
            // button6
            // 
            this.button6.BackColor = System.Drawing.Color.Silver;
            this.button6.Font = new System.Drawing.Font("Segoe UI Light", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button6.Location = new System.Drawing.Point(26, 659);
            this.button6.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(145, 35);
            this.button6.TabIndex = 23;
            this.button6.Text = "Thêm";
            this.button6.UseVisualStyleBackColor = false;
            // 
            // dgvImport
            // 
            this.dgvImport.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvImport.Location = new System.Drawing.Point(6, 5);
            this.dgvImport.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgvImport.Name = "dgvImport";
            this.dgvImport.RowHeadersWidth = 51;
            this.dgvImport.Size = new System.Drawing.Size(1241, 457);
            this.dgvImport.TabIndex = 3;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1300, 773);
            this.Controls.Add(this.tabControl1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Form1";
            this.Text = "Form1";
            this.tabControl1.ResumeLayout(false);
            this.Sách.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBooks)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCategories)).EndInit();
            this.Order.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrders)).EndInit();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvImport)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private TabControl tabControl1;
        private TabPage Sách;
        private TabPage tabPage2;
        private DataGridView dgvBooks;
        private Panel panel1;
        private Button AddBook;
        private Button DeleteBook;
        private Button EditBook;
        private Label BookName;
        private Label AuthorName;
        private TextBox txtTitle;
        private TextBox txtPrice;
        private Label Price;
        private ComboBox cbPublisher;
        private Label NXB;
        private ComboBox cbCategory;
        private ComboBox cbAuthor;
        private Label Category;
        private Label Description;
        private RichTextBox txtDescription;
        private Label label1;
        private TextBox textBox1;
        private DataGridView dgvCategories;
        private TabPage Order;
        private Panel panel2;
        private Label CreatedDay;
        private Button button1;
        private Button button2;
        private Button button3;
        private DataGridView dgvOrders;
        private TextBox textBox4;
        private Label CustomerName;
        private DateTimePicker dateTimePicker1;
        private Label phoneNumber;
        private TextBox textBox2;
        private Label label2;
        private TextBox textBox3;
        private TabPage tabPage3;
        private TextBox textBox6;
        private Label label4;
        private DateTimePicker dateTimePicker2;
        private Label label6;
        private Button button4;
        private Button button5;
        private Button button6;
        private DataGridView dgvImport;
    }
}

