package com.amigos.infotap.homeautomationsystem;

import java.io.IOException;
import java.util.ArrayList;
import java.util.List;
import org.apache.http.NameValuePair;
import org.apache.http.client.ResponseHandler;
import org.apache.http.client.entity.UrlEncodedFormEntity;
import org.apache.http.client.methods.HttpPost;
import org.apache.http.impl.client.BasicResponseHandler;
import org.apache.http.impl.client.DefaultHttpClient;
import org.apache.http.message.BasicNameValuePair;
import org.json.JSONException;
import org.json.JSONObject;

import android.app.ProgressDialog;
import android.os.AsyncTask;
import android.os.Bundle;
import android.app.Activity;
import android.util.Log;
import android.view.Menu;
import android.view.View;
import android.widget.AdapterView;
import android.widget.Button;
import android.widget.CompoundButton;
import android.widget.EditText;
import android.widget.RadioGroup;
import android.widget.RadioGroup.OnCheckedChangeListener;
import android.widget.Spinner;
import android.widget.Switch;
import android.widget.TextView;
import android.widget.Toast;

import com.amigos.infotap.homeautomationsystem.R;
import com.amigos.infotap.homeautomationsystem.ServiceHandler;


public class MainActivity extends Activity {

    //private String Daemon = "/HAS/Daemon.php";
    private String piUpdate = ":8002/controldevice";
    private String refresh = "/HAS/refresh.php";

    private Switch switch1,switch2,switch3,switch4;
    private Spinner spinner;
    private Button reUp,con;
    private EditText editText1,editText;
    private JSONObject jsonObj=null;
    public void Update()
    {

        String roomNum = spinner.getSelectedItem().toString().replace("Room ","");
        new AddNewPrediction().execute("roomNum",roomNum ,refresh);

        //System.out.print(jsonObj);

        Switch [] s = {switch1,switch2,switch3,switch4};
        int i=0;
        if(jsonObj!=null) {
            for (Switch sw : s) {
                i = i + 1;

                try {
                    int checker = jsonObj.getInt("Dev" + i);
                    System.out.println(checker);

                    if (sw.isChecked() && checker == 0) {
                        sw.setChecked(false);
                    } else if (!sw.isChecked() && checker == 1) {
                        sw.setChecked(true);
                    }
                } catch (JSONException e) {
                    e.printStackTrace();
                }

            }
        }
        else
        {
            System.out.println("Json Failed!");
        }
    }

    @Override
    public void onResume()
    {
        super.onResume();
        Update();
    }

    @Override
    public void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);



        switch1 = (Switch) findViewById(R.id.dev1);
        switch2 = (Switch) findViewById(R.id.dev2);
        switch3 = (Switch) findViewById(R.id.dev3);
        switch4 = (Switch) findViewById(R.id.dev4);
        reUp = (Button) findViewById(R.id.refresh);
        con = (Button) findViewById(R.id.con);
        editText = (EditText)findViewById(R.id.editText);
        editText1 = (EditText)findViewById(R.id.editText2);
        spinner = (Spinner) findViewById(R.id.spinner);


        Switch sx1 [] ={switch1,switch2,switch3,switch4};
        for (final Switch s : sx1)
        {

            s.setOnClickListener(new View.OnClickListener() {
                @Override
                public void onClick(View v) {
                    String i=s.getText().toString().replace("DEVICE ","");
                    if (s.isChecked()) {
                        String roomNum = spinner.getSelectedItem().toString().replace("Room ","");
                        new AddNewPrediction().execute(roomNum , "Dev"+i, "1",piUpdate);
                        //new AddNewPrediction().execute(roomNum , "Dev"+i, "1",Daemon);


                        Toast.makeText(getApplicationContext(),"Device "+i+"Status Changed!",Toast.LENGTH_LONG);
                        //do something;
                    } else {
                        String roomNum = spinner.getSelectedItem().toString().replace("Room ","");

                        new AddNewPrediction().execute(roomNum ,  "Dev"+i, "0",piUpdate);
                        //new AddNewPrediction().execute(roomNum ,  "Dev"+i, "0",Daemon);

                        Toast.makeText(getApplicationContext(),"Device "+i+"Status Changed!",Toast.LENGTH_LONG);
                        //do something
                    }

                }
            });
        }



        spinner.setOnItemSelectedListener(new AdapterView.OnItemSelectedListener() {
                    @Override
                    public void onItemSelected(AdapterView<?> parent, View view, int position, long id) {

                    Update();
                    Update();
                    Update();
                    }

                    @Override
                    public void onNothingSelected(AdapterView<?> parentView) {

                    }

                });

        con.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                String ip = editText.getText().toString();
                String piIP = editText1.getText().toString();
                //Daemon="http://"+ip+Daemon;
                refresh="http://"+ip+refresh;
                piUpdate="http://"+piIP+piUpdate;
                Toast.makeText(getApplicationContext(), "IP SET to "+ip+" and Connected to Home !!!",Toast.LENGTH_LONG).show();


            }
        });
        reUp.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                Update();
            }
        });
    }
    @Override
    public boolean onCreateOptionsMenu(Menu menu) {
        getMenuInflater().inflate(R.menu.main, menu);
        return true;
    }

    private class AddNewPrediction extends AsyncTask<String, Void, Void> {
        ProgressDialog progressDialog;
        @Override
        protected void onPreExecute() {
            super.onPreExecute();
            progressDialog = new ProgressDialog(
                    MainActivity.this);
            progressDialog.setMessage("Contacting Server ...");
            progressDialog.setCancelable(false);
            progressDialog.show();
        }

        @Override
        protected Void doInBackground(String arg[]) {
            // TODO Auto-generated method stub

            String URL;
            List<NameValuePair> params = new ArrayList<NameValuePair>();
            if (arg[2].contains("refresh") )
            {

                String roomNum;
                roomNum = arg[1];
                URL = arg[2];

                System.out.println("" + roomNum + " Refreshing");

                // Preparing post params
                params.add(new BasicNameValuePair("roomNum", roomNum));
                System.out.print(params);
            }
            else{
                String devNum;
                String roomNum;
                String status ;
                roomNum = arg[0];
                devNum = arg[1];
                status = arg[2];
                URL = arg[3];

                System.out.println("" + devNum + " " + status);

                // Preparing post params
                params.add(new BasicNameValuePair("roomNum", roomNum));
                params.add(new BasicNameValuePair("devNum", devNum));
                params.add(new BasicNameValuePair("status", status));

                System.out.print(params);

            }

            String json = ServiceHandler.makeServiceCall(URL,ServiceHandler.POST, params);

            Log.d("HAS Daemon Request: ", "> " + json);

            if (json != null) {
                try {
                    jsonObj = new JSONObject(json);
                    boolean error = jsonObj.getBoolean("error");
                    // checking for error node in json
                    if (!error) {
                        // new category created successfully
                        Log.e("HAS Contacted ",
                                "> " + jsonObj.getString("message"));
                        // test the python RASP PI code
                        if(URL.contains("8002"))
                        System.out.println("devNum: "+jsonObj.getString("devNum"));
//                        Toast.makeText(getApplicationContext(), "HAS Contacted: "+jsonObj.getString("message"),Toast.LENGTH_LONG).show();
                    } else {
                        Log.e("HAS Error: ",
                                "> " + jsonObj.getString("message"));

//                        Toast.makeText(getApplicationContext(), "HAS Error: "+jsonObj.getString("message"),Toast.LENGTH_LONG).show();
                    }

                } catch (JSONException e) {
                    e.printStackTrace();
                }

            } else {
                Log.e("JSON Data", "JSON data error!");
            }
            return null;
        }

        @Override
        protected void onPostExecute(Void result) {
            super.onPostExecute(result);
            progressDialog.cancel();
        }
    }
}