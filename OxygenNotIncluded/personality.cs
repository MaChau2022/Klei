// C:\Apps\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using System;
using System.Collections.Generic;
using Klei.AI;

namespace Database
{
	// Token: 0x02000CEB RID: 3307
	public class Personalities : ResourceSet<Personality>
	{
		// Token: 0x0600681A RID: 26650 RVA: 0x00280054 File Offset: 0x0027E254
		public Personalities()
		{
            // List<string> roster = new List<string>(
            //     new string[] {
            //         "Nisbet",
            //         "Bubbles",
            //         "Ashkan",
            //         "Ellie",
            //         "Jean",
            //         "Otto",
            //         "Ren",
            //         "Pei",
			// 		"Lindsay",
			// 		"Harold",
            //     }
            // );
			foreach (Personalities.PersonalityInfo personalityInfo in AsyncLoadManager<IGlobalAsyncLoader>.AsyncLoader<Personalities.PersonalityLoader>.Get().entries)
			{
				Personality resource = new Personality(personalityInfo.Name.ToUpper(), Strings.Get(string.Format("STRINGS.DUPLICANTS.PERSONALITIES.{0}.NAME", personalityInfo.Name.ToUpper())), personalityInfo.Gender.ToUpper(), personalityInfo.PersonalityType, personalityInfo.StressTrait, personalityInfo.JoyTrait, personalityInfo.StickerType, personalityInfo.CongenitalTrait, personalityInfo.HeadShape, personalityInfo.Mouth, personalityInfo.Neck, personalityInfo.Eyes, personalityInfo.Hair, personalityInfo.Body, personalityInfo.Belt, personalityInfo.Cuff, personalityInfo.Foot, personalityInfo.Hand, personalityInfo.Pelvis, personalityInfo.Leg, Strings.Get(string.Format("STRINGS.DUPLICANTS.PERSONALITIES.{0}.DESC", personalityInfo.Name.ToUpper())), personalityInfo.ValidStarter);
                // if (roster.Contains(personalityInfo.Name)) {
                    base.Add(resource);
                // }
			}
		}

		// Token: 0x0600681B RID: 26651 RVA: 0x00280158 File Offset: 0x0027E358
		private void AddTrait(Personality personality, string trait_name)
		{
			Trait trait = Db.Get().traits.TryGet(trait_name);
			if (trait != null)
			{
				personality.AddTrait(trait);
			}
		}

		// Token: 0x0600681C RID: 26652 RVA: 0x00280180 File Offset: 0x0027E380
		private void SetAttribute(Personality personality, string attribute_name, int value)
		{
			Klei.AI.Attribute attribute = Db.Get().Attributes.TryGet(attribute_name);
			if (attribute == null)
			{
				Debug.LogWarning("Attribute does not exist: " + attribute_name);
				return;
			}
			personality.SetAttribute(attribute, value);
		}

		// Token: 0x0600681D RID: 26653 RVA: 0x002801BA File Offset: 0x0027E3BA
		public List<Personality> GetStartingPersonalities()
		{
			return this.resources.FindAll((Personality x) => x.startingMinion);
		}

		// Token: 0x0600681E RID: 26654 RVA: 0x002801E8 File Offset: 0x0027E3E8
		public List<Personality> GetAll(bool onlyEnabledMinions, bool onlyStartingMinions)
		{
			List<string> roster = new List<string>(
                new string[] {
                    "Nisbet".ToUpper(),
                    "Bubbles".ToUpper(),
                    "Ashkan".ToUpper(),
                    "Ellie".ToUpper(),
                    "Jean".ToUpper(),
                    "Otto".ToUpper(),
                    "Ren".ToUpper(),
                    "Pei".ToUpper(),
					"Lindsay".ToUpper(),
					"Harold".ToUpper()
                }
            );
			return this.resources.FindAll(
				(Personality x) => 
					(!onlyStartingMinions || x.startingMinion) && 
					(!onlyEnabledMinions || !x.Disabled) &&
					(roster.Contains(x.nameStringKey))
			);
		}

		// Token: 0x0600681F RID: 26655 RVA: 0x00280220 File Offset: 0x0027E420
		public Personality GetRandom(bool onlyEnabledMinions, bool onlyStartingMinions)
		{
			return this.GetAll(onlyEnabledMinions, onlyStartingMinions).GetRandom<Personality>();
		}

		// Token: 0x06006820 RID: 26656 RVA: 0x00280230 File Offset: 0x0027E430
		public Personality GetPersonalityFromNameStringKey(string name_string_key)
		{
			foreach (Personality personality in Db.Get().Personalities.resources)
			{
				if (personality.nameStringKey.Equals(name_string_key, StringComparison.CurrentCultureIgnoreCase))
				{
					return personality;
				}
			}
			return null;
		}

		// Token: 0x02001BBE RID: 7102
		public class PersonalityLoader : AsyncCsvLoader<Personalities.PersonalityLoader, Personalities.PersonalityInfo>
		{
			// Token: 0x060099AF RID: 39343 RVA: 0x00338E13 File Offset: 0x00337013
			public PersonalityLoader() : base(Assets.instance.personalitiesFile)
			{
			}

			// Token: 0x060099B0 RID: 39344 RVA: 0x00338E25 File Offset: 0x00337025
			public override void Run()
			{
				base.Run();
			}
		}

		// Token: 0x02001BBF RID: 7103
		public class PersonalityInfo : Resource
		{
			// Token: 0x060099B1 RID: 39345 RVA: 0x00338E2D File Offset: 0x0033702D
			public PersonalityInfo()
			{
			}

			// Token: 0x04007D49 RID: 32073
			public int HeadShape;

			// Token: 0x04007D4A RID: 32074
			public int Mouth;

			// Token: 0x04007D4B RID: 32075
			public int Neck;

			// Token: 0x04007D4C RID: 32076
			public int Eyes;

			// Token: 0x04007D4D RID: 32077
			public int Hair;

			// Token: 0x04007D4E RID: 32078
			public int Body;

			// Token: 0x04007D4F RID: 32079
			public int Belt;

			// Token: 0x04007D50 RID: 32080
			public int Cuff;

			// Token: 0x04007D51 RID: 32081
			public int Foot;

			// Token: 0x04007D52 RID: 32082
			public int Hand;

			// Token: 0x04007D53 RID: 32083
			public int Pelvis;

			// Token: 0x04007D54 RID: 32084
			public int Leg;

			// Token: 0x04007D55 RID: 32085
			public string Gender;

			// Token: 0x04007D56 RID: 32086
			public string PersonalityType;

			// Token: 0x04007D57 RID: 32087
			public string StressTrait;

			// Token: 0x04007D58 RID: 32088
			public string JoyTrait;

			// Token: 0x04007D59 RID: 32089
			public string StickerType;

			// Token: 0x04007D5A RID: 32090
			public string CongenitalTrait;

			// Token: 0x04007D5B RID: 32091
			public string Design;

			// Token: 0x04007D5C RID: 32092
			public bool ValidStarter;
		}
	}
}
