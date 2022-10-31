using System;
using System.Collections.Generic;
using WarcraftLegacies.MacroTools.Augments;

namespace WarcraftLegacies.MacroTools.Frames.Books.Augments
{
   public sealed class AugmentPage : Page
   {
      private readonly Dictionary<Augment, AugmentCard> _cardsByAugment = new();
    
      public AugmentPage()
      {
         Rows = 1;
         Columns = 3;
         YOffsetTop = 0.025f;
         YOffsetBot = 0.05f;
      }

      /// <summary>
      /// Un-renders an <see cref="Augment"/> from this <see cref="AugmentPage"/>.
      /// </summary>
      /// <param name="augment"></param>
      public void RemoveAugment(Augment augment)
      {
         if (!_cardsByAugment.TryGetValue(augment, out var augmentCard)) 
            return;
         Cards.Remove(augmentCard);
         _cardsByAugment.Remove(augment);
         augmentCard.Dispose();
      }
    
      /// <summary>
      ///   Renders an Augment on this AugmentPage as a AugmentCard.
      /// </summary>
      private void AddAugment(Augment augment)
      {
         if (CardCount >= CardLimit)
            throw new Exception($"AugmentPage is already at the card limit of {CardLimit} cards.");
         var augmentCard = new AugmentCard(augment, this);
         PositionFrameAtIndex(augmentCard, Cards.Count);
         Cards.Add(augmentCard);
         AddFrame(augmentCard);
         _cardsByAugment.Add(augment, augmentCard);
         augmentCard.OnChoose += OnChoose;
      }

      public void AddAugments(IEnumerable<Augment> augments)
      {
         foreach (var augment in augments)
         {
            AddAugment(augment);
         }
      }
      
      private void OnChoose(object? sender, AugmentCard e)
      {
         try
         {
            Dispose();
         }
         catch (Exception ex)
         {
            Console.WriteLine(ex);
         }
      }
   }
}