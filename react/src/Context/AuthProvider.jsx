import { createContext, useState } from "react";
//import PropTypes from 'prop-types';

const AuthContext = createContext({});

//AuthProvider.propTypes = {
//    children: PropTypes.node.isRequired,
//};

export const AuthProvider = ({ children }) => {
    const [auth, setAuth] = useState({});

    return (
        <AuthContext.Provider value={{ auth, setAuth }}>
            {children}
        </AuthContext.Provider>
    )
}

export default AuthContext;