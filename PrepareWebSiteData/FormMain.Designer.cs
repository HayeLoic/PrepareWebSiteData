namespace PrepareWebSiteData
{
    partial class FormMain
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxPhotographiesFolder = new System.Windows.Forms.TextBox();
            this.buttonReadPhotographies = new System.Windows.Forms.Button();
            this.textBoxPhotographiesResult = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tabControlPhotographies = new System.Windows.Forms.TabControl();
            this.tabPagePhotograpies = new System.Windows.Forms.TabPage();
            this.tabPage3dWork = new System.Windows.Forms.TabPage();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox3dWorkFolder = new System.Windows.Forms.TextBox();
            this.textBox3dWorkResult = new System.Windows.Forms.TextBox();
            this.buttonRead3dWork = new System.Windows.Forms.Button();
            this.tabControlPhotographies.SuspendLayout();
            this.tabPagePhotograpies.SuspendLayout();
            this.tabPage3dWork.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Dossier à lire :";
            // 
            // textBoxPhotographiesFolder
            // 
            this.textBoxPhotographiesFolder.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxPhotographiesFolder.Location = new System.Drawing.Point(83, 6);
            this.textBoxPhotographiesFolder.Name = "textBoxPhotographiesFolder";
            this.textBoxPhotographiesFolder.Size = new System.Drawing.Size(611, 20);
            this.textBoxPhotographiesFolder.TabIndex = 1;
            // 
            // buttonReadPhotographies
            // 
            this.buttonReadPhotographies.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonReadPhotographies.Location = new System.Drawing.Point(708, 3);
            this.buttonReadPhotographies.Name = "buttonReadPhotographies";
            this.buttonReadPhotographies.Size = new System.Drawing.Size(75, 23);
            this.buttonReadPhotographies.TabIndex = 2;
            this.buttonReadPhotographies.Text = "Lire";
            this.buttonReadPhotographies.UseVisualStyleBackColor = true;
            this.buttonReadPhotographies.Click += new System.EventHandler(this.buttonReadPhotographies_Click);
            // 
            // textBoxPhotographiesResult
            // 
            this.textBoxPhotographiesResult.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxPhotographiesResult.Location = new System.Drawing.Point(83, 38);
            this.textBoxPhotographiesResult.Multiline = true;
            this.textBoxPhotographiesResult.Name = "textBoxPhotographiesResult";
            this.textBoxPhotographiesResult.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxPhotographiesResult.Size = new System.Drawing.Size(700, 378);
            this.textBoxPhotographiesResult.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Résultat :";
            // 
            // tabControlPhotographies
            // 
            this.tabControlPhotographies.Controls.Add(this.tabPagePhotograpies);
            this.tabControlPhotographies.Controls.Add(this.tabPage3dWork);
            this.tabControlPhotographies.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlPhotographies.Location = new System.Drawing.Point(0, 0);
            this.tabControlPhotographies.Name = "tabControlPhotographies";
            this.tabControlPhotographies.SelectedIndex = 0;
            this.tabControlPhotographies.Size = new System.Drawing.Size(800, 450);
            this.tabControlPhotographies.TabIndex = 5;
            // 
            // tabPagePhotograpies
            // 
            this.tabPagePhotograpies.Controls.Add(this.label1);
            this.tabPagePhotograpies.Controls.Add(this.label2);
            this.tabPagePhotograpies.Controls.Add(this.textBoxPhotographiesFolder);
            this.tabPagePhotograpies.Controls.Add(this.textBoxPhotographiesResult);
            this.tabPagePhotograpies.Controls.Add(this.buttonReadPhotographies);
            this.tabPagePhotograpies.Location = new System.Drawing.Point(4, 22);
            this.tabPagePhotograpies.Name = "tabPagePhotograpies";
            this.tabPagePhotograpies.Padding = new System.Windows.Forms.Padding(3);
            this.tabPagePhotograpies.Size = new System.Drawing.Size(792, 424);
            this.tabPagePhotograpies.TabIndex = 0;
            this.tabPagePhotograpies.Text = "Photographies";
            this.tabPagePhotograpies.UseVisualStyleBackColor = true;
            // 
            // tabPage3dWork
            // 
            this.tabPage3dWork.Controls.Add(this.label3);
            this.tabPage3dWork.Controls.Add(this.label4);
            this.tabPage3dWork.Controls.Add(this.textBox3dWorkFolder);
            this.tabPage3dWork.Controls.Add(this.textBox3dWorkResult);
            this.tabPage3dWork.Controls.Add(this.buttonRead3dWork);
            this.tabPage3dWork.Location = new System.Drawing.Point(4, 22);
            this.tabPage3dWork.Name = "tabPage3dWork";
            this.tabPage3dWork.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3dWork.Size = new System.Drawing.Size(792, 424);
            this.tabPage3dWork.TabIndex = 1;
            this.tabPage3dWork.Text = "3D Work";
            this.tabPage3dWork.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 8);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Dossier à lire :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 38);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Résultat :";
            // 
            // textBox3dWorkFolder
            // 
            this.textBox3dWorkFolder.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox3dWorkFolder.Location = new System.Drawing.Point(83, 6);
            this.textBox3dWorkFolder.Name = "textBox3dWorkFolder";
            this.textBox3dWorkFolder.Size = new System.Drawing.Size(611, 20);
            this.textBox3dWorkFolder.TabIndex = 6;
            // 
            // textBox3dWorkResult
            // 
            this.textBox3dWorkResult.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox3dWorkResult.Location = new System.Drawing.Point(83, 38);
            this.textBox3dWorkResult.Multiline = true;
            this.textBox3dWorkResult.Name = "textBox3dWorkResult";
            this.textBox3dWorkResult.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox3dWorkResult.Size = new System.Drawing.Size(700, 378);
            this.textBox3dWorkResult.TabIndex = 8;
            // 
            // buttonRead3dWork
            // 
            this.buttonRead3dWork.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonRead3dWork.Location = new System.Drawing.Point(708, 3);
            this.buttonRead3dWork.Name = "buttonRead3dWork";
            this.buttonRead3dWork.Size = new System.Drawing.Size(75, 23);
            this.buttonRead3dWork.TabIndex = 7;
            this.buttonRead3dWork.Text = "Lire";
            this.buttonRead3dWork.UseVisualStyleBackColor = true;
            this.buttonRead3dWork.Click += new System.EventHandler(this.buttonRead3dWork_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tabControlPhotographies);
            this.Name = "FormMain";
            this.Text = "Préparation des données pour le site Angular";
            this.tabControlPhotographies.ResumeLayout(false);
            this.tabPagePhotograpies.ResumeLayout(false);
            this.tabPagePhotograpies.PerformLayout();
            this.tabPage3dWork.ResumeLayout(false);
            this.tabPage3dWork.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxPhotographiesFolder;
        private System.Windows.Forms.Button buttonReadPhotographies;
        private System.Windows.Forms.TextBox textBoxPhotographiesResult;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TabControl tabControlPhotographies;
        private System.Windows.Forms.TabPage tabPagePhotograpies;
        private System.Windows.Forms.TabPage tabPage3dWork;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox3dWorkFolder;
        private System.Windows.Forms.TextBox textBox3dWorkResult;
        private System.Windows.Forms.Button buttonRead3dWork;
    }
}

