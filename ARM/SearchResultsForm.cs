using System.Collections.Generic;
using System.Windows.Forms;
using ARM.MyWorkClasses;

namespace ARM {
    public partial class SearchResultsForm : Form {
        //Поля
        InterfaceManager interfaceManager;

        //Конструктор для фильмов актёра
        public SearchResultsForm(List<film> actorFilms) {
            InitializeComponent();
            interfaceManager = new InterfaceManager();
            interfaceManager.InitializeFilmTable(lvSearchResults, actorFilms);
        }

        //Конструктор для актёров фильма
        public SearchResultsForm(List<actor> filmActors) {
            InitializeComponent();
            interfaceManager = new InterfaceManager();
            interfaceManager.InitializeActorsTable(lvSearchResults, filmActors);
        }
    }
}
