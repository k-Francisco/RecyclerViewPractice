using Android.App;
using Android.Widget;
using Android.OS;
using Android.Support.V7.Widget;
using System;

namespace RecyclerViewPractice
{
    [Activity(Label = "RecyclerViewPractice", MainLauncher = true, Icon = "@drawable/icon", Theme ="@style/Theme.AppCompat.Light.DarkActionBar")]
    public class MainActivity : Activity
    {
        RecyclerView mRecyclerView;
        RecyclerView.LayoutManager mLayoutManager;
        PhotoAlbum mPhotoAlbum;
        PhotoAlbumAdapter mAdapter;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            mPhotoAlbum = new PhotoAlbum();
            // Set our view from the "main" layout resource
            SetContentView (Resource.Layout.Main);

            mRecyclerView = FindViewById<RecyclerView>(Resource.Id.recyclerView);
            mLayoutManager = new LinearLayoutManager(this);
            mRecyclerView.SetLayoutManager(mLayoutManager);
            mAdapter = new PhotoAlbumAdapter(mPhotoAlbum);
            mAdapter.itemClick += MAdapter_ItemClick;

            mRecyclerView.SetAdapter(mAdapter);

            Button addItems = FindViewById<Button>(Resource.Id.btnAdd);

            addItems.Click += delegate {
                    mPhotoAlbum.addPhotos(Resource.Drawable.sample, "Hello");
                    mAdapter.NotifyDataSetChanged();
            };

        }

        private void MAdapter_ItemClick(object sender, int position)
        {
            int photoNum = position + 1;
            Toast.MakeText(this, "This is photo number" + photoNum,ToastLength.Short).Show();
        }
    }
}

