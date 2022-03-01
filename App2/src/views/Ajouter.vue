<template>
  <ion-page>
    <base-layout>
      <template v-slot:slot-1>Ajouter Livre</template>
      <template v-slot:slot-2>
        <ion-buttons slot="start">
          <ion-button color="danger" href="/livre">
            <ion-icon :icon="arrowBack" slot="icon-only"></ion-icon>
          </ion-button>
        </ion-buttons>
      </template>
    </base-layout>
    <ion-content :fullscreen="true">
      <ion-item>
        <ion-label position="floating">Titre</ion-label>
        <ion-input
          v-model="titre"
          type="text"
          placeholder="Livre 1"
          required
        ></ion-input>
      </ion-item>

      <ion-item>
        <ion-label position="floating">Isbm </ion-label>
        <ion-input
          v-model="isbm"
          type="text"
          placeholder="Ref101"
          required
        ></ion-input>
      </ion-item>

      <ion-item>
        <ion-label position="floating">Année Edition</ion-label>
        <ion-input
          v-model="annee"
          type="text"
          placeholder="Année Edition"
          required
        ></ion-input>
      </ion-item>

      <ion-item>
        <ion-label position="floating">Nombre Exemplaire</ion-label>
        <ion-input
          v-model="nombre"
          type="number"
          placeholder="12"
          required
        ></ion-input>
      </ion-item>

      <ion-item>
        <ion-label position="floating">Image </ion-label>
        <ion-input
         
          type="file"
          required
        ></ion-input>
      </ion-item>

      <ion-item>
        <ion-label position="floating">Resume</ion-label>
        <ion-input
          v-model="resume"
          type="text"
          placeholder="opaa opaa"
          required
        ></ion-input>
      </ion-item>

      <div class="app3">
        <ion-buttons>
          <ion-button color="danger" @click="ajouter()" href="/livre">
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
      titre: "",
      isbm: "",
      annee: "",
      nombre: "",
      image: "",
      resume: "",
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
    // FileSelected(event) {
    //   this.image = event.target.files[0];
    //   // upload image in to serveur
    //   let fd = new FormData();
    //   fd.append("image", this.image);
    //   axios
    //     .post("https://localhost:44300/api/livres/Image", fd)
    //     .then((res) => {
    //       this.image = res.data;
    //       console.log(res.data);
    //     })
    //     .catch((rer) => console.log(rer));
    // },

    // ajouter() {
    //   // inserer livre in base de donner
    //   const livre = {
    //     titre: this.titre,
    //     isbm: this.isbm,
    //     anneeEdition: this.annee,
    //     resume: this.resume,
    //     nombre: this.nombre,
    //     image: this.image,
    //   };

      // axios
      //   .post("https://localhost:44300/api/livres", livre)
      //   .then((res) => console.log(res))
      //   .catch((rer) => console.log(rer));

      //this.$router.push({ name: "Livre" });
    //},
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
