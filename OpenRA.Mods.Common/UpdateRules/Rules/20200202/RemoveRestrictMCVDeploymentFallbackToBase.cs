﻿#region Copyright & License Information
/*
 * Copyright 2007-2020 The OpenRA Developers (see AUTHORS)
 * This file is part of OpenRA, which is free software. It is made
 * available to you under the terms of the GNU General Public License
 * as published by the Free Software Foundation, either version 3 of
 * the License, or (at your option) any later version. For more
 * information, see COPYING.
 */
#endregion

using System.Collections.Generic;
using System.Linq;

namespace OpenRA.Mods.Common.UpdateRules.Rules
{
	public class RemoveRestrictMCVDeploymentFallbackToBase : UpdateRule
	{
		public override string Name { get { return "RestrictMCVDeploymentFallbackToBase has been removed from McvManagerBotModule."; } }
		public override string Description
		{
			get
			{
				return "The RestrictMCVDeploymentFallbackToBase property has been removed, and is replaced by an AI \n" +
					   "which will place new bases at resource locations, away from enemies and its own previous bases.\n" +
					   "It will not place any bases within the MaxBaseRadius of its own MCVs, con yards or any enemy.";
			}
		}

		public override IEnumerable<string> UpdateActorNode(ModData modData, MiniYamlNode actorNode)
		{
			foreach (var t in actorNode.ChildrenMatching("McvManagerBotModule"))
				t.RemoveNodes("RestrictMCVDeploymentFallbackToBase");

			yield break;
		}
	}
}
