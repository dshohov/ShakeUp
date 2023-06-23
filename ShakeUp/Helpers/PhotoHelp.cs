namespace ShakeUp.Helpers
{
    public static class PhotoHelp
    {
        public static byte[] GetBytesPhoto(IFormFile fileUpload)
        {
            if (fileUpload != null && fileUpload.Length > 0)
            {
                if (fileUpload.ContentType == "image/svg+xml")
                {
                    using (var memoryStream = new MemoryStream())
                    {
                        fileUpload.CopyTo(memoryStream);
                        byte[] fileBytes = memoryStream.ToArray();
                        return fileBytes;
                    }
                }
            }
            return null;
        }
    }
}
