using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Foundation;
using SmartDropper.Helpers;
using SmartDropper.Model;
using Xamarin.Forms;

[assembly: Dependency(typeof(SmartDropper.iOS.Dependencies.Firestore))]
namespace SmartDropper.iOS.Dependencies
{
    public class Firestore : IFirestore
    {
        public async Task<bool> Delete(Post post)
        {
            try
            {
                var collection = Firebase.CloudFirestore.Firestore.SharedInstance.GetCollection("posts");
                await collection.GetDocument(post.Id).DeleteDocumentAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool Insert(Post post)
        {
            try
            {
                var keys = new[]
                {
                    new NSString("name"),
                    new NSString("surname"),
                    new NSString("diagnose"),
                    new NSString("userID"),
                    new NSString("numOfSmth")
                };
                var values = new NSObject[]
                {
                    new NSString(post.Name),
                    new NSString(post.Surname),
                    new NSString(post.Diagnose),
                    new NSString(Firebase.Auth.Auth.DefaultInstance.CurrentUser.Uid),
                    new NSNumber(post.NumOfSmth)

                };
                var document = new NSDictionary<NSString, NSObject>(keys, values);

                var collection = Firebase.CloudFirestore.Firestore.SharedInstance.GetCollection("posts");
                collection.AddDocument(document);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<List<Post>> Read()
        {
            try
            {
                var collection = Firebase.CloudFirestore.Firestore.SharedInstance.GetCollection("posts");
                var query = collection.WhereEqualsTo("userId", Firebase.Auth.Auth.DefaultInstance.CurrentUser.Uid);
                var documents = await query.GetDocumentsAsync();
                List<Post> posts = new List<Post>();
                foreach (var doc in documents.Documents)
                {
                    var dictionary = doc.Data;
                    var newPost = new Post()
                    {
                        Name = dictionary.ValueForKey(new NSString("name")) as NSString,
                        Surname = dictionary.ValueForKey(new NSString("surname")) as NSString,
                        Diagnose = dictionary.ValueForKey(new NSString("diagnose")) as NSString,
                        NumOfSmth = (int)(dictionary.ValueForKey(new NSString("numOfSmth")) as NSNumber),
                        UserId = dictionary.ValueForKey(new NSString("userID")) as NSString,
                        Id = doc.Id


                    };
                    posts.Add(newPost);
                }
                return posts;
            }
            catch (Exception ex)
            {
                return new List<Post>();
            }


        }

        public async Task<bool> Update(Post post)
        {
            try
            {
                var keys = new[]
                {
                    new NSString("name"),
                    new NSString("surname"),
                    new NSString("diagnose"),
                    new NSString("userID"),
                    new NSString("numOfSmth")
                };
                var values = new NSObject[]
                {
                    new NSString(post.Name),
                    new NSString(post.Surname),
                    new NSString(post.Diagnose),
                    new NSString(Firebase.Auth.Auth.DefaultInstance.CurrentUser.Uid),
                    new NSNumber(post.NumOfSmth)

                };
                var document = new NSDictionary<NSObject, NSObject>(keys, values);

                var collection = Firebase.CloudFirestore.Firestore.SharedInstance.GetCollection("posts");
                await collection.GetDocument(post.Id).UpdateDataAsync(document);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}

