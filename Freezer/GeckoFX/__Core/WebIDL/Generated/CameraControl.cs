namespace Gecko.WebIDL
{
    using System;
    
    
    internal class CameraControl : WebIDLBase
    {
        
        public CameraControl(nsIDOMWindow globalWindow, nsISupports thisObject) : 
                base(globalWindow, thisObject)
        {
        }
        
        public nsISupports Capabilities
        {
            get
            {
                return this.GetProperty<nsISupports>("capabilities");
            }
        }
        
        public string Effect
        {
            get
            {
                return this.GetProperty<string>("effect");
            }
            set
            {
                this.SetProperty("effect", value);
            }
        }
        
        public string WhiteBalanceMode
        {
            get
            {
                return this.GetProperty<string>("whiteBalanceMode");
            }
            set
            {
                this.SetProperty("whiteBalanceMode", value);
            }
        }
        
        public string SceneMode
        {
            get
            {
                return this.GetProperty<string>("sceneMode");
            }
            set
            {
                this.SetProperty("sceneMode", value);
            }
        }
        
        public string FlashMode
        {
            get
            {
                return this.GetProperty<string>("flashMode");
            }
            set
            {
                this.SetProperty("flashMode", value);
            }
        }
        
        public string FocusMode
        {
            get
            {
                return this.GetProperty<string>("focusMode");
            }
            set
            {
                this.SetProperty("focusMode", value);
            }
        }
        
        public double Zoom
        {
            get
            {
                return this.GetProperty<double>("zoom");
            }
            set
            {
                this.SetProperty("zoom", value);
            }
        }
        
        public double FocalLength
        {
            get
            {
                return this.GetProperty<double>("focalLength");
            }
        }
        
        public double FocusDistanceNear
        {
            get
            {
                return this.GetProperty<double>("focusDistanceNear");
            }
        }
        
        public double FocusDistanceOptimum
        {
            get
            {
                return this.GetProperty<double>("focusDistanceOptimum");
            }
        }
        
        public double FocusDistanceFar
        {
            get
            {
                return this.GetProperty<double>("focusDistanceFar");
            }
        }
        
        public double ExposureCompensation
        {
            get
            {
                return this.GetProperty<double>("exposureCompensation");
            }
            set
            {
                this.SetProperty("exposureCompensation", value);
            }
        }
        
        public string IsoMode
        {
            get
            {
                return this.GetProperty<string>("isoMode");
            }
            set
            {
                this.SetProperty("isoMode", value);
            }
        }
        
        public double PictureQuality
        {
            get
            {
                return this.GetProperty<double>("pictureQuality");
            }
            set
            {
                this.SetProperty("pictureQuality", value);
            }
        }
        
        public int SensorAngle
        {
            get
            {
                return this.GetProperty<int>("sensorAngle");
            }
        }
        
        public string MeteringMode
        {
            get
            {
                return this.GetProperty<string>("meteringMode");
            }
            set
            {
                this.SetProperty("meteringMode", value);
            }
        }
        
        public object[] GetMeteringAreas()
        {
            return this.CallMethod<object[]>("getMeteringAreas");
        }
        
        public void SetMeteringAreas()
        {
            this.CallVoidMethod("setMeteringAreas");
        }
        
        public void SetMeteringAreas(object[] meteringAreas)
        {
            this.CallVoidMethod("setMeteringAreas", meteringAreas);
        }
        
        public object[] GetFocusAreas()
        {
            return this.CallMethod<object[]>("getFocusAreas");
        }
        
        public void SetFocusAreas()
        {
            this.CallVoidMethod("setFocusAreas");
        }
        
        public void SetFocusAreas(object[] focusAreas)
        {
            this.CallVoidMethod("setFocusAreas", focusAreas);
        }
        
        public object GetPictureSize()
        {
            return this.CallMethod<object>("getPictureSize");
        }
        
        public void SetPictureSize()
        {
            this.CallVoidMethod("setPictureSize");
        }
        
        public void SetPictureSize(object size)
        {
            this.CallVoidMethod("setPictureSize", size);
        }
        
        public object GetThumbnailSize()
        {
            return this.CallMethod<object>("getThumbnailSize");
        }
        
        public void SetThumbnailSize()
        {
            this.CallVoidMethod("setThumbnailSize");
        }
        
        public void SetThumbnailSize(object size)
        {
            this.CallVoidMethod("setThumbnailSize", size);
        }
        
        public Promise <bool> AutoFocus()
        {
            return this.CallMethod<Promise <bool>>("autoFocus");
        }
        
        public Promise < nsIDOMBlob > TakePicture()
        {
            return this.CallMethod<Promise < nsIDOMBlob >>("takePicture");
        }
        
        public Promise < nsIDOMBlob > TakePicture(object options)
        {
            return this.CallMethod<Promise < nsIDOMBlob >>("takePicture", options);
        }
        
        public Promise StartRecording(object options, nsISupports storageArea, string filename)
        {
            return this.CallMethod<Promise>("startRecording", options, storageArea, filename);
        }
        
        public void StopRecording()
        {
            this.CallVoidMethod("stopRecording");
        }
        
        public void PauseRecording()
        {
            this.CallVoidMethod("pauseRecording");
        }
        
        public void ResumeRecording()
        {
            this.CallVoidMethod("resumeRecording");
        }
        
        public void ResumePreview()
        {
            this.CallVoidMethod("resumePreview");
        }
        
        public Promise Release()
        {
            return this.CallMethod<Promise>("release");
        }
        
        public Promise <object> SetConfiguration()
        {
            return this.CallMethod<Promise <object>>("setConfiguration");
        }
        
        public Promise <object> SetConfiguration(object configuration)
        {
            return this.CallMethod<Promise <object>>("setConfiguration", configuration);
        }
        
        public void ResumeContinuousFocus()
        {
            this.CallVoidMethod("resumeContinuousFocus");
        }
        
        public void StartFaceDetection()
        {
            this.CallVoidMethod("startFaceDetection");
        }
        
        public void StopFaceDetection()
        {
            this.CallVoidMethod("stopFaceDetection");
        }
    }
}
