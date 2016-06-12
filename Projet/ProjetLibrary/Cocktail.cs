﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjetLibrary;
using System.ComponentModel;

namespace ProjetLibrary
{
    /// <summary>
    /// La classe Cocktail qui implémente l'interface IEquatable afin de redéfinir la comparaison.
    /// Et qui implémente l'interface ICocktail afin d'avoir une façade immuable.
    /// </summary>
    public class Cocktail : IEquatable<Cocktail>, INotifyPropertyChanged
    {
        /// <summary>
        /// Nom est le nom du cocktail, il est unique pour tous les cocktails.
        /// </summary>
        public string Nom
        {
            set
            {
                nom = value;
                OnPropretyChanged("nom");
            }
            get { return nom; }
        }
        private string nom;

        /// <summary>
        /// Recette est du texte composé des étapes de la réalisation du cocktail.
        /// </summary>
        public string Recette
        {
            set
            {
                recette = value;
                OnPropretyChanged("recette");
            }
            get { return recette; }
        }
        private string recette;

        /// <summary>
        /// ingredients est la liste d'ingrédients.
        /// </summary>
        private List<Ingredient> ingredients = new List<Ingredient>();
        public ReadOnlyCollection<Ingredient> IngredientRead
        {
            private set
            {
                ingredients = value.ToList();
            }
            get
            {
                return ingredients.AsReadOnly();
            }
        }

        /// <summary>
        /// Propriété calculé permettant de connaitre
        /// </summary>
        public int nbIngredients
        {
            get { return ingredients.Count(); }
        }

        /// <summary>
        /// commentaires est la liste des commentaires laisser par un utilisateurs de type User.
        /// </summary>
        private Dictionary<User, Commentaire> commentaires = new Dictionary<User, Commentaire>();
        public ReadOnlyDictionary<User, Commentaire> CommentaireRead
        {
            get
            {
                return new ReadOnlyDictionary<User, Commentaire>(commentaires.ToDictionary(kvp => kvp.Key as User, kvp => kvp.Value as Commentaire));
            }
        }

        /// <summary>
        /// urlImage est le chemin de l'image dans le projet.
        /// </summary>
        public string UrlImage
        {
            set
            {
                urlImage = value;
                OnPropretyChanged("urlImage");
            }
            get { return urlImage; }
        }
        private string urlImage;

        /// <summary>
        /// Evenement permettant l'actualisation des listes dans la vue après modification d'une collection.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropretyChanged(string p)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(p));
            }
        }

        /// <summary>
        /// Constructeur d'un cocktail sous sa forme la plus élémentaire
        /// </summary>
        /// <param name="nom">le nom</param>
        public Cocktail(string nom)
        {
            this.Nom = nom;
            this.Recette = "Pas de recette !";
        }

        /// <summary>
        /// constructeur d'un cocktail.
        /// </summary>
        /// <param name="nom">prenant un nom</param>
        /// <param name="ingredients">et une liste d'ingrédients</param>
        public Cocktail(string nom, List<Ingredient> ingredients) : this(nom)
        {
            ingredients.ForEach(i => this.ingredients.Add(new Ingredient(i.Nom, i.Quantite, i.Unite)));
        }

        /// <summary>
        /// constructeur numéro 2.
        /// </summary>
        /// <param name="nom"></param>
        /// <param name="recette">prenant une recette</param>
        /// <param name="ingredients"></param>
        public Cocktail(string nom, string recette, List<Ingredient> ingredients) : this(nom, ingredients)
        {
            this.Recette = recette;
        }

        /// <summary>
        /// constructeur numéro 3.
        /// </summary>
        /// <param name="nom"></param>
        /// <param name="recette"></param>
        /// <param name="ingredients"></param>
        /// <param name="url"></param>
        public Cocktail(string nom, string recette, List<Ingredient> ingredients, string url) : this(nom, recette, ingredients)
        {
            this.UrlImage = url;
        }

        /// <summary>
        /// constructeur numéro 4.
        /// </summary>
        /// <param name="nom"></param>
        /// <param name="recette"></param>
        /// <param name="ingredients"></param>
        /// <param name="commentaires"></param>
        /// <param name="url"></param>
        public Cocktail(string nom, string recette, List<Ingredient> ingredients, Dictionary<User, Commentaire> commentaires, string url) : this(nom, recette, ingredients, url)
        {
            foreach (var com in commentaires)
            {
                this.commentaires.Add(com.Key, new Commentaire(com.Value.Titre, com.Value.Texte, com.Value.Note));
            }
        }

        /// <summary>
        /// Méthode pour ajouter un ingrédient au cocktail.
        /// </summary>
        /// <param name="ingredient">prent un ingrédient</param>
        public void ajouterIngredient(Ingredient ingredient)
        {
            if (ingredients == null)
            {
                ingredients = new List<Ingredient>();
            }
            if (!ingredients.Contains(ingredient))
            {
                ingredients.Add(ingredient);
            }
        }

        /// <summary>
        /// Méthode pour supprimer un ingrédient au cocktail.
        /// </summary>
        /// <param name="ingredient"></param>
        public void supprimerIngredients(Ingredient ingredient)
        {
            if (ingredients.Contains(ingredient))
            {
                ingredients.Remove(ingredient);
            }
        }

        /// <summary>
        /// Méthode permettant d'ajouter un commentaire pour un utilisateur au dictionnaire.
        /// </summary>
        /// <param name="u">un utilisateur</param>
        /// <param name="c">un commentaire</param>
        public void laisserCommentaire(User u, Commentaire c)
        {
            /*try
            {*/
            commentaires.Add(u, new Commentaire(c.Titre, c.Texte, c.Note));
            /* }
             #pragma warning disable CS0168 // La variable est déclarée mais jamais utilisée
             catch (Exception e)
             {
                 supprimerCommentaire(u);
                 commentaires.Add(u, new Commentaire(c.Titre, c.Texte, c.Note));
             }*/
        }

        /// <summary>
        /// Méthode permettant de récupérer la value dans le dictionnaire de commentaire
        /// </summary>
        /// <param name="u">en fonction de la clé de type User</param>
        /// <returns>la value commentaire</returns>
        public Commentaire returnComment(User u)
        {
            return commentaires[u];
        }

        /// <summary>
        /// Méthode permettant de supprimer un commentaire (la KeyValuePair)
        /// </summary>
        /// <param name="u">en connaissant l'utilisateur</param>
        public void supprimerCommentaire(User u)
        {
            commentaires.Remove(u);
        }

        /// <summary>
        /// Redéfinition de la méthode GetHashCode.
        /// </summary>
        /// <returns>un entier : le code de hashage</returns>
        public override int GetHashCode()
        {
            return Nom.GetHashCode();
        }

        /// <summary>
        /// Redéfinition de la méthode Equals.
        /// </summary>
        /// <param name="obj">prenant un objet de type object</param>
        /// <returns>un booléen</returns>
        public override bool Equals(object obj)
        {
            if (object.ReferenceEquals(obj, null)) return false;
            if (object.ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return this.Equals(obj as Cocktail);
        }

        /// <summary>
        /// Création de la méthode Equals.
        /// </summary>
        /// <param name="com">prenant un objet de type Cocktail</param>
        /// <returns>un booléen</returns>
        public bool Equals(Cocktail cocktail)
        {
            return this.Nom.Equals(cocktail.Nom);
        }

        /// <summary>
        /// Redéfinition de la méthode ToString.
        /// </summary>
        /// <returns>rune chaîne de caractère</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder(Nom);
            sb.Append("\n");
            foreach (Ingredient ing in ingredients)
            {
                sb.AppendFormat("{0}\n", ing.ToString());
            }
            sb.AppendFormat("{0}\n", Recette);
            foreach (Commentaire comm in commentaires.Values)
            {
                sb.AppendFormat("{0}\n", comm.ToString());
            }
            return sb.ToString();
        }

    }
}
