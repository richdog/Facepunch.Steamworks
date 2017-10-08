
namespace Facepunch.Steamworks
{
    public partial class Workshop
    {
        public class ItemPreview
        {
            public uint PreviewIndex { get; private set; }
            public string URLorVideoID { get; private set; }
            public string OriginalFileName { get; private set; }
            public SteamNative.ItemPreviewType PreviewType { get; private set; }

            internal PreviewSubmitAction SubmitAction { get; private set; }

            internal string updateFilePathOrVideoURL { get; private set; }

            public ItemPreview( string filePathOrVideoURL, SteamNative.ItemPreviewType previewType )
            {
                updateFilePathOrVideoURL = filePathOrVideoURL;
                PreviewType = previewType;
                SubmitAction = PreviewSubmitAction.Create;
            }

            internal ItemPreview( uint previewIndex, string URLorVideoID, string originalFileName, SteamNative.ItemPreviewType previewType )
            {
                this.PreviewIndex = previewIndex;
                this.URLorVideoID = URLorVideoID;
                this.OriginalFileName = originalFileName;
                this.PreviewType = previewType;
                this.SubmitAction = PreviewSubmitAction.None;
            }

            public bool Remove()
            {
                if (SubmitAction == PreviewSubmitAction.Create)
                    return false;

                SubmitAction = PreviewSubmitAction.Remove;
                return true;
            }

            public bool UpdateItemPreviewFile(string filePathOrVideoURL)
            {
                if (SubmitAction == PreviewSubmitAction.Create)
                    return false;

                updateFilePathOrVideoURL = filePathOrVideoURL;
                SubmitAction = PreviewSubmitAction.Update;
                return true;
            }

            internal enum PreviewSubmitAction
            {
                None,
                Create,
                Remove,
                Update
            }
        }
    }
}
