﻿using System.Linq;
using Robust.Client.AutoGenerated;
using Robust.Client.UserInterface;
using Robust.Client.UserInterface.Controls;
using Robust.Client.UserInterface.XAML;
using Robust.Shared.Utility;

namespace Content.Client.SS220.UserInterface.System.Chat.Controls;

[GenerateTypedNameReferences]
public sealed partial class HighlightPopup : Popup
{
    public List<string> Words { get; }

    public Color ColorWords { get; private set; }
    public HighlightPopup()
    {
        RobustXamlLoader.Load(this);
        Words = new List<string>();
        ButtonNew.OnPressed += _ => SaveWords_Click();
    }

    private void SaveWords_Click()
    {
        Words.Clear();
        var input = Rope.Collapse(TextEditWords.TextRope);
        var words = input.Split(',').Select(w => w.Trim());

        foreach (var word in words)
        {
            if (Words.Contains(word))
            {
                continue;
            }
            if (!string.IsNullOrEmpty(word))
            {
                Words.Add(word);
            }
        }

        ColorWords = ColorForWords.Color;
    }
}

