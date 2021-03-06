﻿//
// GitTests.cs
//
// Author:
//       Manish Sinha <manish.sinha@xamarin.com>
//
// Copyright (c) 2015 Xamarin Inc.
//
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
// THE SOFTWARE.

using NUnit.Framework;
using System;
using MonoDevelop.Ide.Commands;

namespace UserInterfaceTests
{
	[TestFixture]
	[Category ("Git")]
	public class GitTests : VCSBase
	{
		[Test]
		public void TestGitSSHClone ()
		{
			TestClone ("git@github.com:mono/jurassic.git");
			Ide.WaitForSolutionLoaded (TakeScreenShot);
		}

		[Test]
		public void TestGitHTTPSClone ()
		{
			TestClone ("https://github.com/mono/jurassic.git");
			Ide.WaitForSolutionLoaded (TakeScreenShot);
		}

		[Test]
		public void TestCommit ()
		{
			var templateOptions = new TemplateSelectionOptions {
				CategoryRoot = OtherCategoryRoot,
				Category = ".NET",
				TemplateKindRoot = GeneralKindRoot,
				TemplateKind = "Console Project"
			};
			CreateBuildProject (templateOptions, delegate {
				System.Threading.Thread.Sleep (2000);
				TestCommit ("First commit");
			}, new GitOptions { UseGit = true, UseGitIgnore = true});
		}

		[Test]
		public void TestNoChangesStashOperation ()
		{
			var templateOptions = new TemplateSelectionOptions {
				CategoryRoot = OtherCategoryRoot,
				Category = ".NET",
				TemplateKindRoot = GeneralKindRoot,
				TemplateKind = "Console Project"
			};
			CreateBuildProject (templateOptions, delegate {
				System.Threading.Thread.Sleep (2000);
				TestCommit ("First commit");
				Session.ExecuteCommand (FileCommands.CloseAllFiles);
				Assert.Throws <TimeoutException> (() => TestGitStash ("No changes stash attempt"));
				Ide.WaitForStatusMessage (new [] {"No changes were available to stash"}, 20);
			}, new GitOptions { UseGit = true, UseGitIgnore = true});
		}

		[Test]
		public void TestStashWithoutHeadCommit ()
		{
			var templateOptions = new TemplateSelectionOptions {
				CategoryRoot = OtherCategoryRoot,
				Category = ".NET",
				TemplateKindRoot = GeneralKindRoot,
				TemplateKind = "Console Project"
			};
			CreateBuildProject (templateOptions, delegate {
				Assert.Throws <TimeoutException> (() => TestGitStash ("Stash without head commit"));
				TakeScreenShot ("Stash-Window-Doesnt-Show");
			}, new GitOptions { UseGit = true, UseGitIgnore = true});
		}

		[Test]
		public void TestStashAndUnstashSuccessful ()
		{
			var templateOptions = new TemplateSelectionOptions {
				CategoryRoot = OtherCategoryRoot,
				Category = ".NET",
				TemplateKindRoot = GeneralKindRoot,
				TemplateKind = "Console Project"
			};
			CreateBuildProject (templateOptions, delegate {
				System.Threading.Thread.Sleep (2000);
				TestCommit ("First commit");

				Session.ExecuteCommand (FileCommands.CloseFile);
				System.Threading.Thread.Sleep (3000);

				Session.ExecuteCommand (TextEditorCommands.InsertNewLine);
				System.Threading.Thread.Sleep (2000);
				Session.ExecuteCommand (FileCommands.SaveAll);
				System.Threading.Thread.Sleep (4000);
				TakeScreenShot ("Inserted New Line");

				TestGitStash ("Entered new blank line");


				System.Threading.Thread.Sleep (3000);
				TakeScreenShot ("After-Stash");

				TestGitUnstash ();

				System.Threading.Thread.Sleep (4000);
				TakeScreenShot ("Untash-Successful");
			}, new GitOptions { UseGit = true, UseGitIgnore = true});
		}
	}
}

