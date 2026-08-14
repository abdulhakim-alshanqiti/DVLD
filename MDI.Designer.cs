namespace Contacts
{
    partial class MDI
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
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.findXToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addXToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.updateXToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removeXToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.addFruitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.button1 = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.findXToolStripMenuItem,
            this.addXToolStripMenuItem,
            this.updateXToolStripMenuItem,
            this.removeXToolStripMenuItem,
            this.toolStripMenuItem2,
            this.addFruitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 22);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // findXToolStripMenuItem
            // 
            this.findXToolStripMenuItem.Name = "findXToolStripMenuItem";
            this.findXToolStripMenuItem.Size = new System.Drawing.Size(127, 22);
            this.findXToolStripMenuItem.Text = "&Find X";
            this.findXToolStripMenuItem.Click += new System.EventHandler(this.findXToolStripMenuItem_Click);
            // 
            // addXToolStripMenuItem
            // 
            this.addXToolStripMenuItem.Name = "addXToolStripMenuItem";
            this.addXToolStripMenuItem.Size = new System.Drawing.Size(127, 22);
            this.addXToolStripMenuItem.Text = "Add X";
            // 
            // updateXToolStripMenuItem
            // 
            this.updateXToolStripMenuItem.Name = "updateXToolStripMenuItem";
            this.updateXToolStripMenuItem.Size = new System.Drawing.Size(127, 22);
            this.updateXToolStripMenuItem.Text = "Update X";
            // 
            // removeXToolStripMenuItem
            // 
            this.removeXToolStripMenuItem.Name = "removeXToolStripMenuItem";
            this.removeXToolStripMenuItem.Size = new System.Drawing.Size(127, 22);
            this.removeXToolStripMenuItem.Text = "Remove X";
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(124, 6);
            // 
            // addFruitToolStripMenuItem
            // 
            this.addFruitToolStripMenuItem.Name = "addFruitToolStripMenuItem";
            this.addFruitToolStripMenuItem.Size = new System.Drawing.Size(127, 22);
            this.addFruitToolStripMenuItem.Text = "AddFruit";
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(4, 1, 0, 1);
            this.menuStrip1.Size = new System.Drawing.Size(533, 24);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(98, 94);
            this.button1.Margin = new System.Windows.Forms.Padding(2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(227, 42);
            this.button1.TabIndex = 1;
            this.button1.Text = "Show Sub Form";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // MDI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(533, 292);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "MDI";
            this.Text = "MDI";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem findXToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addXToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem updateXToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem removeXToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem addFruitToolStripMenuItem;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.Button button1;
    }
}