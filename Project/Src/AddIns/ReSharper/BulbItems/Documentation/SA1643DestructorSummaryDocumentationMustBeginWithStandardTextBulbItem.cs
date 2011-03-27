// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SA1643DestructorSummaryDocumentationMustBeginWithStandardTextBulbItem.cs" company="http://stylecop.codeplex.com">
//   MS-PL
// </copyright>
// <license>
//   This source code is subject to terms and conditions of the Microsoft 
//   Public License. A copy of the license can be found in the License.html 
//   file at the root of this distribution. If you cannot locate the  
//   Microsoft Public License, please send an email to dlr@microsoft.com. 
//   By using this source code in any fashion, you are agreeing to be bound 
//   by the terms of the Microsoft Public License. You must not remove this 
//   notice, or any other, from this software.
// </license>
// <summary>
//   SA1642: SA1643DestructorSummaryDocumentationMustBeginWithStandardTextBulbItem.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace StyleCop.ReSharper.BulbItems.Documentation
{
    #region Using Directives

    using JetBrains.ProjectModel;
    using JetBrains.ReSharper.Psi.CSharp.Tree;
    using JetBrains.TextControl;

    using StyleCop.ReSharper.BulbItems.Framework;
    using StyleCop.ReSharper.CodeCleanup.Rules;
    using StyleCop.ReSharper.Core;

    #endregion

    /// <summary>
    /// SA1642: SA1643DestructorSummaryDocumentationMustBeginWithStandardTextBulbItem.
    /// </summary>
    public class SA1643DestructorSummaryDocumentationMustBeginWithStandardTextBulbItem : V5BulbItemImpl
    {
        #region Public Methods

        /// <summary>
        /// The execute transaction inner.
        /// </summary>
        /// <param name="solution">
        /// The solution.
        /// </param>
        /// <param name="textControl">
        /// The text control.
        /// </param>
        public override void ExecuteTransactionInner(ISolution solution, ITextControl textControl)
        {
            var element = Utils.GetElementAtCaret(solution, textControl);

            if (element != null)
            {
                var destructorDeclaration = element.GetContainingElement<IDestructorDeclaration>(true);
                if (destructorDeclaration != null)
                {
                    new DocumentationRules().EnsureDestructorSummaryDocBeginsWithStandardText(destructorDeclaration);
                }
            }
        }

        #endregion
    }
}