using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.Support.V7.Widget;


namespace RecyclerViewPractice
{
    public class Photo {

        public int mPhotoID { get; set; }
        public string mCaption { get; set; }
    }

    public class PhotoAlbum {

        List<Photo> listPhotos = new List<Photo> {};
        Random random;

        public PhotoAlbum()
        {
            random = new Random();
        }

        public void addPhotos(int photoID, string caption) {

            listPhotos.Add(new Photo() {mPhotoID = photoID, mCaption = caption });
        }

        public int numPhotos {

            get { return listPhotos.Count; }
        }

        public Photo this[int i] {

            get { return listPhotos[i]; }
        }

    }

    public class PhotoViewHolder : RecyclerView.ViewHolder {

        public ImageView image { get; set; }
        public TextView caption { get; set; }

        public PhotoViewHolder(View itemView, Action<int> listener) : base(itemView) {

            image = itemView.FindViewById<ImageView>(Resource.Id.imageView);
            caption = itemView.FindViewById<TextView>(Resource.Id.textView);
            itemView.Click += (sender, e) => listener(Position);
        }
    }

    public class PhotoAlbumAdapter : RecyclerView.Adapter
    {
        public event EventHandler<int> itemClick;
        public PhotoAlbum mPhotoAlbum;

        public PhotoAlbumAdapter(PhotoAlbum photoAlbum) {

            mPhotoAlbum = photoAlbum;
        }

        public override int ItemCount
        {
            get
            {
                return mPhotoAlbum.numPhotos;
            }
        }

        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            PhotoViewHolder vh = holder as PhotoViewHolder;
            vh.image.SetImageResource(mPhotoAlbum[position].mPhotoID);
            vh.caption.Text = mPhotoAlbum[position].mCaption;
        }

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            View itemView = LayoutInflater.From(parent.Context).Inflate(Resource.Layout.PhotoCard, parent, false);
            PhotoViewHolder vh = new PhotoViewHolder(itemView,OnClick);
            return vh;
        }

        private void OnClick(int obj)
        {
            if (itemClick != null) {
                itemClick(this, obj);
            }
        }
    }
}