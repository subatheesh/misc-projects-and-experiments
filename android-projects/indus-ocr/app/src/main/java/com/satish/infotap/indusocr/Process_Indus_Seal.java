package com.satish.infotap.indusocr;

import android.app.Activity;
import android.app.ProgressDialog;
import android.content.Context;
import android.content.ContextWrapper;
import android.content.Intent;
import android.graphics.Bitmap;
import android.graphics.BitmapFactory;
import android.graphics.PixelFormat;
import android.hardware.Camera;
import android.os.AsyncTask;
import android.os.Bundle;
import android.util.Base64;
import android.util.Log;
import java.util.ArrayList;
import android.view.Menu;
import android.view.MenuItem;
import android.view.SurfaceHolder;
import android.view.SurfaceView;
import android.view.View;
import android.widget.Button;
import android.widget.EditText;
import android.widget.Toast;

import org.apache.http.HttpResponse;
import org.apache.http.NameValuePair;
import org.apache.http.client.HttpClient;
import org.apache.http.client.entity.UrlEncodedFormEntity;
import org.apache.http.client.methods.HttpPost;
import org.apache.http.impl.client.DefaultHttpClient;
import org.apache.http.message.BasicNameValuePair;
import org.apache.http.util.EntityUtils;
import org.w3c.dom.Text;

import java.io.File;
import java.io.FileOutputStream;
import java.io.IOException;
import java.net.URL;



public class Process_Indus_Seal extends Activity implements SurfaceHolder.Callback{

    SurfaceView mSurfaceView;
    SurfaceHolder mSurfaceHolder;
    static Camera mCamera = null;
    boolean mPreviewRunning;
    Button btncapture, btnset;
    String ba1;
    EditText et;
    public static String URL;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_process__indus__seal);

        btnset = (Button) findViewById(R.id.button1);
        et = (EditText) findViewById(R.id.editText1);
        btnset.setOnClickListener(new View.OnClickListener() {

            @Override
            public void onClick(View v) {
               URL = "http://" + et.getText() + "/Indus/save.php";
                Toast.makeText(getApplicationContext(), "IP set successfully! ", Toast.LENGTH_LONG).show();
            }
        });

        btncapture=(Button) findViewById(R.id.button2);
        mSurfaceView = (SurfaceView) findViewById(R.id.surfaceView);
        mSurfaceHolder = mSurfaceView.getHolder();
        mSurfaceHolder.addCallback(this);
        mSurfaceHolder.setType(SurfaceHolder.SURFACE_TYPE_PUSH_BUFFERS);


        btncapture.setOnClickListener(new View.OnClickListener() {

            @Override
            public void onClick(View v) {
                //take picture here
                mCamera.takePicture(null, null, mPictureCallback);
            }
        });
    }

    Camera.PictureCallback mPictureCallback = new Camera.PictureCallback() {
        public void onPictureTaken(byte[] imageData, Camera c) {

            Bitmap bitmap = BitmapFactory.decodeByteArray(imageData, 0, imageData.length);
            String file_path = saveToInternalStorage(bitmap);
            ba1 = Base64.encodeToString(imageData,Base64.NO_WRAP);
            Toast.makeText(getApplicationContext(), "Image stored successfully at " + file_path, Toast.LENGTH_LONG).show();

            new uploadToServer().execute();
            Intent intent;
            intent = new Intent(, IndusTextRegion.class);
            intent.setFlags(Intent.FLAG_ACTIVITY_CLEAR_TOP);
            startActivity(intent);
            finish();
        }
    };

    private String saveToInternalStorage(Bitmap bitmapImage){
        //ContextWrapper cw = new ContextWrapper(getApplicationContext());
        // path to /data/data/yourapp/app_data/imageDir
        // File directory = cw.getDir("imageDir", Context.MODE_PRIVATE);
        // Create imageDir
        // File mypath = new File(directory,"temp1.jpg");

        String directory = "/sdcard/temp.jpg";
        FileOutputStream fos = null;
        try {

            fos = new FileOutputStream(directory);

            // Use the compress method on the BitMap object to write image to the OutputStream
            bitmapImage.compress(Bitmap.CompressFormat.JPEG, 100, fos);
            fos.close();
        } catch (Exception e) {
            e.printStackTrace();
        }
        return directory;
    }

    @Override
    public boolean onCreateOptionsMenu(Menu menu) {
        // Inflate the menu; this adds items to the action bar if it is present.
        getMenuInflater().inflate(R.menu.process__indus__seal, menu);
        return true;
    }

    @Override
    public boolean onOptionsItemSelected(MenuItem item) {
        // Handle action bar item clicks here. The action bar will
        // automatically handle clicks on the Home/Up button, so long
        // as you specify a parent activity in AndroidManifest.xml.
        int id = item.getItemId();
        if (id == R.id.action_settings) {
            return true;
        }
        return super.onOptionsItemSelected(item);
    }

    @Override
    public void surfaceCreated(SurfaceHolder surfaceHolder) {
            mCamera = Camera.open();
    }

    @Override
    public void surfaceChanged(SurfaceHolder surfaceHolder, int format, int w, int h) {
        if (mPreviewRunning) {
            mCamera.stopPreview();
        }

        mCamera.setDisplayOrientation(90);
        Camera.Parameters p = mCamera.getParameters();
        p.setPreviewSize(352,288);

        mCamera.setParameters(p);
        try {
            mCamera.setPreviewDisplay(surfaceHolder);
        } catch (IOException e) {
            e.printStackTrace();
        }
        mCamera.startPreview();
        mPreviewRunning = true;

    }

    @Override
    public void surfaceDestroyed(SurfaceHolder surfaceHolder) {
        mCamera.stopPreview();
        mPreviewRunning = false;
        mCamera.release();
        mCamera = null;

    }

    public class uploadToServer extends AsyncTask<Void, Void, String> {

        private ProgressDialog pd = new ProgressDialog(Process_Indus_Seal.this);
        protected void onPreExecute() {
            super.onPreExecute();
            pd.setMessage("Wait image uploading!");
            pd.show();
        }

        @Override
        protected String doInBackground(Void... params) {

            ArrayList<NameValuePair> nameValuePairs = new ArrayList<NameValuePair>();
            nameValuePairs.add(new BasicNameValuePair("base64", ba1));
            nameValuePairs.add(new BasicNameValuePair("ImageName", "temp.jpg"));
            try {
                HttpClient httpclient = new DefaultHttpClient();
                HttpPost httppost = new HttpPost(URL);
                httppost.setEntity(new UrlEncodedFormEntity(nameValuePairs));
                HttpResponse response = httpclient.execute(httppost);
                String st = EntityUtils.toString(response.getEntity());
                Log.v("log_tag", "In the try " + st);

            } catch (Exception e) {
                Log.v("log_tag", "Error in http connection " + e.toString());
            }
            return "Success";

        }

        protected void onPostExecute(String result) {
            super.onPostExecute(result);
            pd.hide();
            pd.dismiss();
        }
    }
}
