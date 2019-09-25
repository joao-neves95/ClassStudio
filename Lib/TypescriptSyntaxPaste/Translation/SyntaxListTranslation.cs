﻿/*
 * Copyright (c) 2019 João Pedro Martins Neves (shivayl) - All Rights Reserved.
 *
 * ClassStudio is licensed under the GNU Lesser General Public License (LGPL),
 * version 3, located in the root of this project, under the name "LICENSE.md".
 *
 */

using Microsoft.CodeAnalysis;
using System.Collections.Generic;
using System.Linq;

namespace RoslynTypeScript.Translation
{
    public class SyntaxListTranslation<T, ST> : SyntaxListBaseTranslation<T, ST> where T : SyntaxNode where ST : SyntaxTranslation
    {
        private SyntaxList<T> syntaxList;

        public SyntaxListTranslation()
        {
            SyntaxCollection = new List<SyntaxTranslation>();
        }

        public SyntaxListTranslation(SyntaxList<T> syntaxList, SyntaxTranslation parent) : base( parent )
        {
            this.syntaxList = syntaxList;
            this.Parent = parent;
            SyntaxCollection = syntaxList.Select( f => f.Get<SyntaxTranslation>( this ) ).ToList();
        }



        protected override string InnerTranslate()
        {
            return string.Join( "\r\n", SyntaxCollection.Select( f => f.Translate() ) );
        }

    }
}

