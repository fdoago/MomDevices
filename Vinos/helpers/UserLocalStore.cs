using System;
using Android.Content;

namespace Vinos
{
	/**
 	 - Created by tundealao on 29/03/15, for Android.
 	 - Modified by LACI on 1/01/16, for Xamarin.
	**/


	public class UserLocalStore {

		public const String SP_NAME = "userDetails";
		private ISharedPreferences mSharedPrefs;
		private ISharedPreferencesEditor mPrefsEditor;

		public UserLocalStore(Context context) {
			mSharedPrefs = context.GetSharedPreferences(SP_NAME, 0);
		}

		public void storeUserData(User user) {
			mPrefsEditor = mSharedPrefs.Edit ();
			mPrefsEditor.PutInt("user_id", user.user_id);
			mPrefsEditor.PutString("nickname", user.nickname);
			mPrefsEditor.PutString ("password", user.password);
			mPrefsEditor.Commit();
		}

		public void setUserLoggedIn(bool loggedIn) {
			mPrefsEditor = mSharedPrefs.Edit ();
			mPrefsEditor.PutBoolean("loggedIn", loggedIn);
			mPrefsEditor.Commit();
		}

		public void setRemember(bool remember) {
			mPrefsEditor = mSharedPrefs.Edit ();
			mPrefsEditor.PutBoolean("remember", remember);
			mPrefsEditor.Commit();
		}

		public void clearUserData() {
			mPrefsEditor = mSharedPrefs.Edit ();
			mPrefsEditor.Clear();
			mPrefsEditor.Commit();
		}

		public bool checkRemember(){
			if (mSharedPrefs.GetBoolean ("remember", true) == true) {
				return true;
			} else {
				return false;
			}

		}

		public bool checkLoggedIn(){
			if (mSharedPrefs.GetBoolean ("loggedIn", true) == true) {
				return true;
			} else {
				return false;
			}

		}

		public userDTO getLoggedInUser() {
			if (mSharedPrefs.GetBoolean("loggedIn", false) == false) {
				return null;
			}

			int user_id = mSharedPrefs.GetInt("user_id", 0);
			String nickname = mSharedPrefs.GetString("nickname", "");
			String password = mSharedPrefs.GetString("password", "");
			User user = new User(user_id, nickname, password);
			return user;
		}
	}
}

