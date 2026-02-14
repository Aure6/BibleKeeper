using System;

namespace BibleKeeper.Client.Models
{
    public class BibleFavorite
    {
        // ID unique généré localement pour gérer le favori (suppression/modif)
        public Guid Id { get; set; } = Guid.NewGuid();

        // --- Données de référence (Immuables, pour retrouver la source) ---
        public string BibleId { get; set; } // Ex: "KJV" ou "LSG"
        public string BookId { get; set; }  // Ex: "JHN" pour Jean
        public string ChapterId { get; set; } // Ex: "JHN.3"
        public string VerseId { get; set; }   // Ex: "JHN.3.16"

        // --- Données Modifiables par l'utilisateur ---

        // Le titre ou la référence (Ex: "Jean 3:16")
        public string DisplayTitle { get; set; }

        // Le texte du verset. L'utilisateur peut vouloir le paraphraser ou corriger.
        public string VerseContent { get; set; }

        // Ajout personnel demandé implicitement (pour "modifier/enrichir")
        public string PersonalNotes { get; set; }

        // Méta-données
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? LastModified { get; set; }
    }
}