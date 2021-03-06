package com.example.carrillo.santamarta;

import android.content.Intent;
import android.os.Bundle;
import android.os.Handler;
import android.support.v7.app.AppCompatActivity;
import android.util.Patterns;
import android.view.View;
import android.widget.Button;
import android.widget.EditText;
import android.widget.ImageButton;
import android.widget.Toast;

import java.util.Timer;
import java.util.TimerTask;
import java.util.regex.Pattern;
/**
 * Created by Carrillo on 9/21/2017.
 */
public class InsertClientsActivity extends AppCompatActivity {
    private EditText txtCode;
    private EditText txtName;
    private EditText txtFirstName;
    private EditText txtSecondName;
    private EditText txtEmail;
    private EditText txtPhone;
    private EditText txtCellphone;
    private EditText txtAddress;
    private EditText txtNameCompany;
    private Button insert;
    private Button back;
    private String token = "";
    private Contextdb contextdb = new Contextdb();
    /**
     * @param savedInstanceState
     * metodo onCreate de InsertClientsActivity
     */
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_clients_create);
        txtCode = (EditText) findViewById(R.id.txt_code);
        txtName = (EditText) findViewById(R.id.txt_Name);
        txtFirstName = (EditText) findViewById(R.id.txt_firstName);
        txtSecondName = (EditText) findViewById(R.id.txt_secondName);
        txtEmail = (EditText) findViewById(R.id.txt_email);
        txtPhone = (EditText) findViewById(R.id.txt_phone);
        txtCellphone = (EditText) findViewById(R.id.txt_cellPhone);
        txtAddress = (EditText) findViewById(R.id.txt_address);
        txtNameCompany = (EditText) findViewById(R.id.txt_nameCompany);
        insert = (Button) findViewById(R.id.btn_insert);
        back = (Button) findViewById(R.id.btn_back);
        token = MainActivity.token;
        final Contextdb contextdb = new Contextdb();
        back.setOnClickListener(new View.OnClickListener(){
            @Override
            public void onClick(View v) {
                if(session()==false) {
                    Intent menu = new Intent(InsertClientsActivity.this, ClientsActivity.class);
                    startActivity(menu);
                    finish();
                }
            }
        });
        insert.setOnClickListener(new View.OnClickListener(){
            @Override
            public void onClick(View v) {
                if(check()==true) {
                    if (session() == false) {
                        insert.setEnabled(false);
                        back.setEnabled(false);
                        Client client = new Client();
                        if (txtPhone.getText().toString().equals("")) {
                            client.setPhone("null");
                        } else {
                            String phone = txtPhone.getText().toString();
                            phone = phone.substring(0, 4) + "-" + phone.substring(4, phone.length());
                            client.setPhone(phone);
                        }
                        if (txtCellphone.getText().toString().equals("")) {
                            client.setCellPhone("null");
                        } else {
                            String cellPhone = txtPhone.getText().toString();
                            cellPhone = cellPhone.substring(0, 4) + "-" + cellPhone.substring(4, cellPhone.length());
                            client.setCellPhone(cellPhone);
                        }
                        client.setName(txtName.getText().toString());
                        client.setFirstName(txtFirstName.getText().toString());
                        client.setSecondName(txtSecondName.getText().toString());
                        client.setEmail(txtEmail.getText().toString());
                        client.setAddress(txtAddress.getText().toString());
                        client.setCode(txtCode.getText().toString());
                        if (txtNameCompany.getText().toString().equals("")) {
                            client.setNameCompany("null");
                        } else {
                            client.setNameCompany(txtNameCompany.getText().toString());
                        }
                        String response = contextdb.insertClients(client, token);
                        switch (response) {
                            case "200":
                                Toast.makeText(getApplicationContext(), "Cliente ingresado correctamente", Toast.LENGTH_LONG).show();
                                // SLEEP 2 SECONDS HERE ...
                                final Handler handler = new Handler();
                                Timer t = new Timer();
                                t.schedule(new TimerTask() {
                                    public void run() {
                                        handler.post(new Runnable() {
                                            public void run() {
                                                insert.setEnabled(true);
                                                back.setEnabled(true);
                                                Intent menu = new Intent(InsertClientsActivity.this, ClientsActivity.class);
                                                startActivity(menu);
                                                finish();
                                            }
                                        });
                                    }
                                }, 1000);
                                break;
                            case "400":
                                insert.setEnabled(true);
                                back.setEnabled(true);
                                Toast.makeText(getApplicationContext(), "¡El codigo ingresado ya existe en el sistema!", Toast.LENGTH_LONG).show();
                                break;
                            case "500":
                                insert.setEnabled(true);
                                back.setEnabled(true);
                                Toast.makeText(getApplicationContext(), "¡Fallo al insertar cliente!", Toast.LENGTH_LONG).show();
                                break;
                            default:
                                insert.setEnabled(true);
                                back.setEnabled(true);
                                break;
                        }
                    }
                }
            }
        });
     }
    /**
     * @param email
     * @return boolean
     * metodo de validar email
     */
    private boolean validatedEmail(String email) {
        Pattern pattern = Patterns.EMAIL_ADDRESS;
        return pattern.matcher(email).matches();
    }
    /**
     * @return
     */
     public boolean check(){
         if(txtName.getText().toString().equals("") || txtFirstName.getText().toString().equals("") || txtSecondName.getText().toString().equals("")){
                 Toast.makeText(getApplicationContext(), "¡Ingrese nombre y apellidos completos!", Toast.LENGTH_LONG).show();
                 return false;
         }
         if(txtNameCompany.getText().toString().equals("")){
             Toast.makeText(getApplicationContext(), "¡Ingrese un nombre de compañia!", Toast.LENGTH_LONG).show();
             return false;
         }
         if(txtCellphone.getText().toString().equals("")&&txtPhone.getText().toString().equals("")){
             Toast.makeText(getApplicationContext(), "¡Ingrese un numero de telefono residencial o uno celular!", Toast.LENGTH_LONG).show();
             return false;
         }else {
             if(txtCellphone.getText().length()<8 && txtPhone.getText().length()<8){
                 Toast.makeText(getApplicationContext(), "¡El formato de telefono residencial o celular no valido!", Toast.LENGTH_LONG).show();
                 return false;
             }
         }
         if(txtAddress.getText().toString().equals("")){
             Toast.makeText(getApplicationContext(), "¡Ingrese una dirección del cliente!", Toast.LENGTH_LONG).show();
             return false;
         }
         if(txtCode.getText().toString().equals("")){
             Toast.makeText(getApplicationContext(), "¡Ingrese el codigo del cliente!", Toast.LENGTH_LONG).show();
             return false;
         }
         if(!txtEmail.getText().toString().equals("")){
             boolean validated = validatedEmail(txtEmail.getText().toString());
             if (validated==false){
                 Toast.makeText(getApplicationContext(), "¡Formato de correo incorrecto!", Toast.LENGTH_LONG).show();
                 return false;
             }
         }
         return true;
     }
    /**
     * @return boolean
     * metodo de verificacion de sesion
     */
    public boolean session(){
        String responce = contextdb.getSession(token);
        if(responce.toString().equals("false")){
            Toast.makeText(getApplicationContext(), "¡Sesión expirada, por favor vuelva a loguear su cuenta!", Toast.LENGTH_LONG).show();
            // SLEEP 2 SECONDS HERE ...
            final Handler handler = new Handler();
            Timer t = new Timer();
            t.schedule(new TimerTask() {
                public void run() {
                    handler.post(new Runnable() {
                        public void run() {
                            Intent menu = new Intent(InsertClientsActivity.this, MainActivity.class);
                            startActivity(menu);
                            finish();
                        }
                    });
                }
            }, 1000);
            return true;
        }else if(responce.toString().equals("error")){
            Toast.makeText(getApplicationContext(), "¡Error en la conexión con el servidor!", Toast.LENGTH_LONG).show();
            // SLEEP 2 SECONDS HERE ...
            final Handler handler = new Handler();
            Timer t = new Timer();
            t.schedule(new TimerTask() {
                public void run() {
                    handler.post(new Runnable() {
                        public void run() {
                            Intent menu = new Intent(InsertClientsActivity.this, MainActivity.class);
                            startActivity(menu);
                            finish();
                        }
                    });
                }
            }, 1000);
            return true;
        }
        return false;
    }
}
