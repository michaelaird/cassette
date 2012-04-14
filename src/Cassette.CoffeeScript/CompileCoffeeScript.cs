﻿using System;
using Cassette.BundleProcessing;
using Cassette.Configuration;

namespace Cassette.Scripts
{
    public class CompileCoffeeScript : IBundleProcessor<Bundle>
    {
        readonly ICompiler coffeeScriptCompiler;
        readonly CassetteSettings settings;

        public CompileCoffeeScript(ICompiler coffeeScriptCompiler, CassetteSettings settings)
        {
            this.coffeeScriptCompiler = coffeeScriptCompiler;
            this.settings = settings;
        }

        public void Process(Bundle bundle)
        {
            foreach (var asset in bundle.Assets)
            {
                if (asset.Path.EndsWith(".coffee", StringComparison.OrdinalIgnoreCase))
                {
                    asset.AddAssetTransformer(new CompileAsset(coffeeScriptCompiler, settings.SourceDirectory));                    
                }
            }
        }
    }
}