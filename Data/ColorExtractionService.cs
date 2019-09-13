using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using ColorPaletteEngine.ColorPalettes;
using Microsoft.Office.ColorExtraction.ColorPalettes;

namespace WebApp.Data
{
    public class ColorExtractionService
    {
        public Task<ColorPalette[]> GetColorPalettesAsync(ColorExtractionModel model)
        {
            var engine = new ColorEngine(new List<IColorPaletteFactory>() {
                 new AnalogousPaletteFactory(),
                 new Analogous2SeedsPaletteFactory()
            });
            using (var imageStream = new MemoryStream(model.Image))
            {
                return Task.FromResult(engine.GetSuggestedPalettes(imageStream,
                    accentAndTBContrastThreshold: model.accentAndTBContrastThreshold,
                    tbContrastThreshold: model.tbContrastThreshold,
                    hlAndFhlContrastThreshold: model.hlAndFhlContrastThreshold
                ).ToArray());
            }
        }
    }
}
