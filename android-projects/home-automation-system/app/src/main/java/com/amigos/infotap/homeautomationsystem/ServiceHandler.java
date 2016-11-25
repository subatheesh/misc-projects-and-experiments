package com.amigos.infotap.homeautomationsystem;

/**
 * Created by $@T!$# on 27-03-2015.
 */
import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStream;
import java.io.InputStreamReader;
import java.io.UnsupportedEncodingException;
import java.util.List;
import org.apache.http.HttpEntity;
import org.apache.http.HttpResponse;
import org.apache.http.NameValuePair;
import org.apache.http.client.ClientProtocolException;
import org.apache.http.client.ResponseHandler;
import org.apache.http.client.entity.UrlEncodedFormEntity;
import org.apache.http.client.methods.HttpGet;
import org.apache.http.client.methods.HttpPost;
import org.apache.http.client.utils.URLEncodedUtils;
import org.apache.http.impl.client.BasicResponseHandler;
import org.apache.http.impl.client.DefaultHttpClient;

import android.util.Log;

public class ServiceHandler {

    public final static int GET = 1;
    public final static int POST = 2;
    static String Httpresponse=null;

    public ServiceHandler() {

    }

    public static String makeServiceCall(String url, int method,List<NameValuePair> params)
    {
        try {

            DefaultHttpClient httpClient = new DefaultHttpClient();
            ResponseHandler<String> responseHandler = new BasicResponseHandler();

            //System.out.println("HElloooooooo");
            if (method == POST) {
                //System.out.println("POOOOOOOOOOOOOOOST");
                HttpPost httpPost = new HttpPost(url);
                if(params!=null)
                httpPost.setEntity(new UrlEncodedFormEntity(params));
                //System.out.println(httpPost.getParams());
                Httpresponse = httpClient.execute(httpPost,responseHandler);
                System.out.println(Httpresponse);

            } else if (method == GET) {
                if(params!=null)
                {String paramString = URLEncodedUtils.format(params, "UTF-8");
                url += "?" + paramString;}

                HttpGet httpGet = new HttpGet(url);

                Httpresponse = httpClient.execute(httpGet, responseHandler);
            }

        } catch (Exception e) {
            e.printStackTrace();
        }

        return Httpresponse;
    }
}
