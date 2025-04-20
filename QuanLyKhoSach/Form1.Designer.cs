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
            this.tabControl1.SuspendLayout();
            this.Sách.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBooks)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCategories)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.Sách);
            this.tabControl1.Controls.Add(this.tabPage2);
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
            this.txtDescription.TextChanged += new System.EventHandler(this.txtDescription_TextChanged_1);
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
    }
}

