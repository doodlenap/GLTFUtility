﻿using System.Collections.Generic;
using Newtonsoft.Json;

namespace Siccity.GLTFUtility {
	public abstract class GLTFProperty {
		[JsonIgnore] public GLTFObject glTFObject { get; private set; }
		[JsonIgnore] public bool isLoaded { get; private set; }

		protected abstract bool OnLoad();

		public bool Load(GLTFObject glTFObject) {
			this.glTFObject = glTFObject;
			if (OnLoad()) isLoaded = true;
			return isLoaded;
		}

		/// <summary> Convenience method. Load multiple GLTFProperties with null check </summary>
		public static void Load(GLTFObject glTFObject, params GLTFProperty[] properties) {
			if (properties == null) return;
			for (int i = 0; i < properties.Length; i++) {
				if (properties[i] != null) {
					properties[i].Load(glTFObject);
				}
			}
		}

		/// <summary> Convenience method. Load multiple GLTFProperties with null check </summary>
		public static void Load<T>(GLTFObject glTFObject, IList<T> properties) where T : GLTFProperty {
			if (properties == null) return;
			for (int i = 0; i < properties.Count; i++) {
				if (properties[i] != null) {
					properties[i].Load(glTFObject);
				}
			}
		}
	}
}