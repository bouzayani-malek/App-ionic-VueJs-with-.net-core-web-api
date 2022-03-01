<template>
  <ion-page>
    <base-layout>
      <template v-slot:slot-1>Ajouter Etudiant</template>
      <template v-slot:slot-2>
        <ion-buttons slot="start">
          <ion-button color="danger" href="/etudiant">
            <ion-icon :icon="arrowBack" slot="icon-only"></ion-icon>
          </ion-button>
        </ion-buttons>
      </template>
    </base-layout>
    <ion-content :fullscreen="true">
      <ion-item>
        <ion-label position="floating">Nom :</ion-label>
        <ion-input
          v-model="nom"
          type="text"
          placeholder="nom"
          required
        ></ion-input>
      </ion-item>

      <ion-item>
        <ion-label position="floating">Prenom : </ion-label>
        <ion-input
          v-model="prenom"
          type="text"
          placeholder="prenom"
          required
        ></ion-input>
      </ion-item>

      <ion-item>
        <ion-label position="floating">Classe :</ion-label>
        <ion-input
          v-model="classe"
          type="text"
          placeholder="classe"
          required
        ></ion-input>
      </ion-item>

      <div class="app3">
        <ion-buttons>
          <ion-button color="danger" @click="ajouter()" href="/etudiant">
            ajouter
            <ion-icon :icon="add"></ion-icon>
          </ion-button>
        </ion-buttons>
      </div>
     
    </ion-content>
  </ion-page>
</template>

<script>
import BaseLayout from "../components/BaseLayout.vue";
import { IonPage, IonIcon, IonButtons, IonButton, IonInput } from "@ionic/vue";
import { arrowBack, add } from "ionicons/icons";
import { defineComponent } from "vue";
//import axios from "axios";

export default defineComponent({
  data() {
    return {
      add,
      arrowBack,
      nom: "",
      prenom: "",
      classe: "",
    };
  },
  components: {
    IonPage,
    IonIcon,
    IonButtons,
    IonButton,
    BaseLayout,
    IonInput,
  },

  methods: {
    // ajouter() {
    //   // inserer livre in base de donner
    //   const etudiant = {
    //     nom: this.nom,
    //     prenom: this.prenom,
    //     classe: this.classe
    //   };

    //   axios
    //     .post("https://localhost:44300/api/Etudiants", etudiant)
    //     .then((res) => console.log(res))
    //     .catch((rer) => console.log(rer));

      
    // },
  },
});
</script>
<style>
ion-input {
  border-radius: 20px !important;
  border: 1px solid #e5c234 !important;
  --background: #f6f9bf !important;
}
ion-label {
  color: red;
  font: 1.2em larger;
}
.app3 {
  width: 24%;
  margin-left: 40%;
  text-align: center;
  background-color: #e5c234;
  border-radius: 20px;
}
.item {
  --background: #f6f9bf !important;
  --border-radius: 20px;
  padding: 3px;
 
  --border-style: none;
}
</style>
