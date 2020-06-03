using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ARM {
    public partial class SearchObjectSelectingForm : Form {
        //Поля
        public object SelectedItem { get; private set; }
        //Конструктор для выбора актёров
        public SearchObjectSelectingForm(List<actor> actors) {
            InitializeComponent();
            Text = "Выберите актёра для поиска";
            gbItems.Text = "Актёры";
            foreach(var actor in actors) {
                cbItems.Items.Add(actor);
            }
        }

        //Конструктор для выбора фильмов
        public SearchObjectSelectingForm(List<film> films) {
            InitializeComponent();
            Text = "Выберите фильм для поиска";
            gbItems.Text = "Фильмы";
            foreach (var film in films) {
                cbItems.Items.Add(film);
            }
        }

        //Принять выбор
        private void bAccept_Click(object sender, EventArgs e) {
            if (cbItems.SelectedItem == null) {
                MessageBox.Show("Критерий поиска не выбран!", "Поиск");
                return;
            }
            SelectedItem = cbItems.SelectedItem;
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
