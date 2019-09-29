﻿/*
 * Copyright (c) 2019 João Pedro Martins Neves (shivayl) - All Rights Reserved.
 *
 * ClassStudio is licensed under the GNU Lesser General Public License (LGPL),
 * version 3, located in the root of this project, under the name "LICENSE.md".
 *
 */

using RoslynTypeScript.Translation;

namespace RoslynTypeScript.Contract
{
    public interface ITranslationVisitor
    {
        void Visit(SyntaxTranslation translation);
    }
}
