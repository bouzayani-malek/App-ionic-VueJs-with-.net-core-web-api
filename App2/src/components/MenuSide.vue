<template>
  <ion-menu menu-id="main-menu" content-id="main">
    <ion-header>
      <ion-toolbar>
        <ion-title> Accueil </ion-title>
      </ion-toolbar>
    </ion-header>
    <ion-content>
      <ion-list>
         <ion-item  href="/home"> Home </ion-item>
        <ion-item  href="/livre"> Gérer Livre </ion-item>
        <ion-item href="/etudiant"> Gérer Etudiant </ion-item>
        <ion-item href="/empreint"> Empreint Livre </ion-item>
        <ion-item href="/remise"> Remise Livre </ion-item>
      
      </ion-list>
    </ion-content>
    <ion-footer class="ion-no-border">
  <ion-toolbar>
    <ion-title>Deconnetion</ion-title>
    <ion-buttons slot="end">
          <ion-button color="danger" >
            <ion-icon :icon="logOut" ></ion-icon>
          </ion-button>
        </ion-buttons>
  </ion-toolbar>
</ion-footer>
  </ion-menu>
</template>
<script>
import {
  IonHeader,
  IonToolbar,
  IonTitle,
  IonContent,
  IonList,
  IonItem,
} from "@ionic/vue";
import {  logOut } from "ionicons/icons";
import { defineComponent } from "vue";
export default defineComponent({
  data(){
    return{
      logOut
    }
  },
  components: { IonHeader, IonToolbar, IonTitle, IonContent, IonList, IonItem },
});
</script>
<style>
</style>