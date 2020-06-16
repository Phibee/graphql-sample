import React, {useState, useEffect} from 'react';
import './App.css';
import GridContainer from './components/GridContainer'
import '@progress/kendo-theme-default/dist/all.css';
// import { HttpLink, InMemoryCache, ApolloLink, ApolloClient } from 'apollo-boost';
import { ApolloProvider } from 'react-apollo';
import { ApolloClient } from 'apollo-client';
import { ApolloLink } from 'apollo-link'
import { onError } from 'apollo-link-error';
import { HttpLink } from 'apollo-link-http';
import { InMemoryCache } from 'apollo-cache-inmemory';
import axios from 'axios'
// apollo client setup
// const enchancedFetch = (url, init) => {
//   // const token = getToken()
//   console.log(url)
//   return fetch(url, {
//       // ...init,
//       // mode: 'cors',
//       // credentials: false,
//       headers: {
//           ...init.headers,
//           'Content-Type': 'application/json',
//           'Access-Control-Allow-Origin': 'http://localhost:3000',
//           // ...(token && { authorization: `Bearer ${token}` }),
//       },
//   }).then(response => console.log(response));
// }

let data = { query: "{books(skip: 2 take: 2){nodes{id, title, price}}}"};
// axios.post("http://localhost:51090/api", {
//   ...data 
// })
// .then(function (response) {
//   console.log(response);
// })
// .catch(function (error) {
//   console.log(error);
// });

// fetch("http://localhost:51090/api", {
//   method: 'POST',
//   // data: JSON.stringify(data),
//   // credentials: "omit",
//   mode: "no-cors", // 'cors' by default
//   body: JSON.stringify(data),
//   // mode: 'cors',
//   headers: { 
//     'Access-Control-Allow-Headers': 'Content-Type',
//     "Content-Type": "application/json",
//         "Access-Control-Request-Headers": "*",
//         "Access-Control-Request-Method": "GET, POST",
//     'Access-Control-Allow-Origin': 'http://localhost:3000',
//     // 'Access-Control-Allow-Methods': 'GET, POST',
//     // "Sec-Fetch-Site": "cross-site"
//  }
// }).then(response => {
// console.log(response)
// })


// const client = new ApolloClient({
//   link: new HttpLink({
//     uri: '/api',
//     fetchOptions: {
//       mode: 'cors',
//     },
//     fetch: enchancedFetch,
//     headers: {
//       // 'content-type': 'application/json',
//       'Content-Type': 'application/json',
//       'Access-Control-Allow-Origin': '*'
//     },
//   }),
//   cache: new InMemoryCache({
//     addTypename: false
//   }) ,
//   // uri: 'http://localhost:51090/api',
//   // headers: {
//   //   'Content-Type': 'application/json',
//   //   // 'Access-Control-Allow-Origin': 'http://localhost:3000',
//   //   'Access-Control-Allow-Credentials': true,
//   // },
// })

const client = new ApolloClient({
  link: ApolloLink.from([
    onError(({ graphQLErrors, networkError }) => {
      if (graphQLErrors)
        graphQLErrors.forEach(({ message, locations, path }) =>
          console.log(
            `[GraphQL error]: Message: ${message}, Location: ${locations}, Path: ${path}`,
          ),
        );
      if (networkError) console.log(`[Network error]: ${networkError}`);
    }),
    new HttpLink({
      uri: '/api',
      credentials: false,
      headers: {
      // 'Content-Type': 'application/json',
      'Access-Control-Allow-Origin': '*',
      // 'Access-Control-Allow-Credentials': true,
      }, 
      fetchOptions: {
        mode: 'cors'
      }
    })
  ]),
  cache: new InMemoryCache()
});

function App() {
  const [rowState, setRowState] = useState({
    inEdit: true,
    selectedItem: null
  });

  useEffect(() => {

    // fetch("/api", {
    //   method: 'POST',
    //   headers: {
    //       "Content-Type": "application/json",
    //       'Access-Control-Allow-Origin': '*',
    //   },
    //   mode: 'cors',
    //   body: JSON.stringify(data)
    // }).then(response => console.log(response));
  }, [])

  const changeRowSelection = (row) => {
    setRowState({
      inEdit: true,
      selectedItem: row
    })
  }

  return (
    // <div> </div>
    <ApolloProvider client={client}>
      <div className="App">
        <GridContainer changeRowSelection={(e) => console.log(e)} />
      </div>
    </ApolloProvider>
  );
}

export default App;
