import React, { useState, useEffect } from "react";
import "./App.css";
import GridContainer from "./components/GridContainer";
import "@progress/kendo-theme-default/dist/all.css";
// import { HttpLink, InMemoryCache, ApolloLink, ApolloClient } from 'apollo-boost';
import { ApolloProvider } from "react-apollo";
import { ApolloClient } from "apollo-client";
import { ApolloLink } from "apollo-link";
import { onError } from "apollo-link-error";
import { HttpLink } from "apollo-link-http";
import { InMemoryCache } from "apollo-cache-inmemory";
import axios from "axios";
import { Formik } from "formik";
import LoginForm from "./components/LoginForm";

let data = { query: "{books(skip: 2 take: 2){nodes{id, title, price}}}" };

const client = new ApolloClient({
     link: ApolloLink.from([
          onError(({ graphQLErrors, networkError }) => {
               if (graphQLErrors)
                    graphQLErrors.forEach(({ message, locations, path }) =>
                         console.log(
                              `[GraphQL error]: Message: ${message}, Location: ${locations}, Path: ${path}`,
                         ),
                    );
               if (networkError)
                    console.log(`[Network error]: ${networkError}`);
          }),
          new HttpLink({
               uri: "/api",
               credentials: false,
               headers: {
                    // 'Content-Type': 'application/json',
                    "Access-Control-Allow-Origin": "*",
                    // 'Access-Control-Allow-Credentials': true,
               },
               fetchOptions: {
                    mode: "cors",
               },
          }),
     ]),
     cache: new InMemoryCache(),
});

function App() {
     return (
          <div>
               <ApolloProvider client={client}>
                    <LoginForm />
                    <div className="App">
                         <GridContainer
                              changeRowSelection={(e) => console.log(e)}
                         />
                    </div>
               </ApolloProvider>
          </div>
     );
}

export default App;
